using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinetuningModel
{
    public partial class Form2 : Form
    {
        Form1 form1 = new Form1();
        public Form2()
        {
            InitializeComponent();
        }
        private const string apiKey = "api key";
        private const string modelEndpoint = "https://api.openai.com/v1/chat/completions";

        private void Form2_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            string metin = textBox1.Text;

            // API isteği yap
            string cevap = ChatGPTIstegiYap(metin);

            // Cevabı ekrana yazdır

            textBox1.Clear();
            textBox2.Text += "Siz: " + metin + Environment.NewLine;
            textBox2.Text += "ChatGPT: " + cevap + Environment.NewLine;
            textBox2.Text += "-------------------------------" + Environment.NewLine;


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
                string jsonData = "{\"model\": \"" + gpt3_5Model + "\", \"messages\": [{\"role\": \"system\", \"content\": \"You are a helpful assistant.\"}," +
                    "{\"role\": \"user\", \"content\": \"" + metin + "\"}], \"max_tokens\": " + maxTokens + "}";

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



        private void button2_Click_1(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }
    }
}
