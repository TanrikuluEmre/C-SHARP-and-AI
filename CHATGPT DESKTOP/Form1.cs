using System;
using System.Drawing;
using System.IO;

using System.Net;
using System.Text;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CHATGPT_DESKTOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const string apiKey = "apikey";
        private const string modelEndpoint = "https://api.openai.com/v1/chat/completions";

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;
            darkmodeKapat();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string metin = txtMetin.Text;

            // API isteği yap
            string cevap = ChatGPTIstegiYap(metin);

            // karanlık modu cevaba göre kapatma ya da açma işlemi
            if (cevap.ToLower().Contains("dark mode") || cevap.ToLower().Contains("karanlık mod"))
            {
                string soru = "chatgpt seninle bir oyun oynayacağız ve bana sadece 1 karakterlik cevap vereceksin. Kullanıcı sorduğu soruda karanlık modu açmak istiyorsa 1, kapatmak istiyorsa 2, başka bir soru soruyorsa sadece 0 olarak cevap ver.";
                string darkModeCevap = ChatGPTIstegiYap(soru+" Kullanıcı = (" + metin + ")");
                switch (darkModeCevap) {
                    case "1":
                        darkmodeAc();
                        break;
                    case "2":
                        darkmodeKapat();
                        break;
                    
                }

            }
            // Cevabı ekrana yazdır
            
            txtMetin.Clear();
            txtCevap.Text += "Siz: " + metin + Environment.NewLine;
            txtCevap.Text += "ChatGPT: " + cevap + Environment.NewLine;
            txtCevap.Text += "-------------------------------" + Environment.NewLine;

            
        }


        private string ChatGPTIstegiYap(string metin)
        {
            try
            {
                // API isteği için gereken parametreleri ayarla
                HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(modelEndpoint);
                istek.Method = "POST";
                istek.Headers.Add("Authorization", "Bearer " + apiKey);
                istek.ContentType = "application/json";

                // GPT-3.5 parametreleri ayarla
                string gpt3_5Model = "gpt-3.5-turbo";
                int maxTokens = 100;

                // İstek verisini oluştur
                string jsonData = "{\"model\": \"" + gpt3_5Model + "\", \"messages\": [{\"role\": \"system\", \"content\": \"You are a helpful assistant.\"}, {\"role\": \"user\", \"content\": \"" + metin + "\"}], \"max_tokens\": " + maxTokens + "}";

                // İstek verisini gönder
                using (StreamWriter streamWriter = new StreamWriter(istek.GetRequestStream()))
                {
                    streamWriter.Write(jsonData);
                }

                // API yanıtını al
                HttpWebResponse yanit = (HttpWebResponse)istek.GetResponse();

                // Yanıtı oku
                using (StreamReader streamReader = new StreamReader(yanit.GetResponseStream(), Encoding.UTF8))
                {
                    string yanitJson = streamReader.ReadToEnd();
                    // JSON yanıtını analiz et
                    dynamic cevap = Newtonsoft.Json.JsonConvert.DeserializeObject(yanitJson);
                    return cevap.choices[0].message.content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("API isteği sırasında bir hata oluştu: " + ex.Message);
                return string.Empty;
            }
        }

        private void txtMetin_TextChanged(object sender, EventArgs e)
        {

        }
        private void darkmodeAc()
        {
            txtMetin.BackColor = Color.Black;
            txtMetin.ForeColor = Color.White;

            txtCevap.BackColor = Color.Black;
            txtCevap.ForeColor = Color.White;
        }
        private void darkmodeKapat()
        {
            txtMetin.BackColor = Color.White;
            txtMetin.ForeColor = Color.Black;

            txtCevap.BackColor = Color.White;
            txtCevap.ForeColor = Color.Black;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMetin.BackColor==Color.White) {

                darkmodeAc();
                
            }
            else if(txtMetin.BackColor == Color.Black)
            {
                darkmodeKapat();
            }

        }
    }
}
