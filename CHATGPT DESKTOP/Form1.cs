using System;

using System.IO;

using System.Net;
using System.Text;

using System.Windows.Forms;

namespace CHATGPT_DESKTOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const string apiKey = "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";
        private const string modelEndpoint = "https://api.openai.com/v1/chat/completions";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string metin = txtMetin.Text;

            // API isteği yap
            string cevap = ChatGPTIstegiYap(metin);

            // Cevabı ekrana yazdır
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
                int maxTokens = 50;

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







    }
}
