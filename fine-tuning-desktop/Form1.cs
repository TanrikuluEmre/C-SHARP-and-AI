using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace fine_tuning_desktop
{
    public partial class Form1 : Form
    {
        // OpenAI API bilgileri
        string apiKey = "API KEY";
        string apiUrl = "https://api.openai.com/v1/engines/ada/completions";
        string fineTuningModelId;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Veri setini dosyadan okuma
            string datasetPath = "C:\\Users\\kanar\\AppData\\Local\\Programs\\Microsoft VS Code\\veri-seti.json";
            var datasetContent = await File.ReadAllTextAsync(datasetPath);

            // API isteði için HttpClient oluþturma
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Fine-tuning için veri setini Ada'ya gönderme
            var fineTuningRequest = new
            {
                examples = JsonConvert.DeserializeObject(datasetContent)
            };

            var fineTuningJsonRequest = JsonConvert.SerializeObject(fineTuningRequest);
            var fineTuningContent = new StringContent(fineTuningJsonRequest, Encoding.UTF8, "application/json");

            var fineTuningResponse = await httpClient.PostAsync(apiUrl + "/fine-tunes", fineTuningContent);
            var fineTuningJsonResponse = await fineTuningResponse.Content.ReadAsStringAsync();

            if (fineTuningResponse.IsSuccessStatusCode)
            {
                dynamic fineTuningResponseObject = JsonConvert.DeserializeObject(fineTuningJsonResponse);
                fineTuningModelId = fineTuningResponseObject.id;
                MessageBox.Show("Fine-tuning completed. Model ID: " + fineTuningModelId);
            }
            else
            {
                MessageBox.Show("Fine-tuning failed with status code: " + fineTuningResponse.StatusCode);
                MessageBox.Show("Response: " + fineTuningJsonResponse);
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            // API isteði için HttpClient oluþturma
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Kullanýcýdan girdi alýnmasý
            string userMessage = textBox1.Text;

            // API isteði için requestBody hazýrlama
            var requestBody = new
            {
                model = fineTuningModelId,
                prompt = $"Chat with Ada:\nUser: {userMessage}\nAda:",
                max_tokens = 100,
                temperature = 0.8
            };

            var jsonRequest = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            // API isteðini gönderme
            var response = await httpClient.PostAsync(apiUrl, content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // API yanýtýný te
            if (response.IsSuccessStatusCode)
            {
                dynamic responseObject = JsonConvert.DeserializeObject(jsonResponse);
                string generatedText = responseObject.choices[0].text;

                // Chatbot yanýtýný düzenleme
                generatedText = generatedText.Trim();
                generatedText = char.ToUpper(generatedText[0]) + generatedText.Substring(1);
                generatedText = generatedText.Replace("\n", "\nAda: ");

                textBox2.Text = generatedText;
            }
            else
            {
                MessageBox.Show("API request failed with status code: " + response.StatusCode);
                MessageBox.Show("Response: " + jsonResponse);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
