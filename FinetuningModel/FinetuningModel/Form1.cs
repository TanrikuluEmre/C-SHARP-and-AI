using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinetuningModel
{
    public partial class Form1 : Form
    {
        string apiKey = "api";
        string filesUrl = "https://api.openai.com/v1/files";
        string fineTunesUrl = "https://api.openai.com/v1/fine-tunes";
        string filePath;
        string status;
        string fineTunedModelId;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            string finetuneId = textBox4.Text;
            modelDurumAsync(finetuneId);
            MessageBox.Show(status);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            filePath = textBox3.Text;
            if (filePath == null)
            {
                MessageBox.Show("filepath is null");
            }
            else
            {
                fineTuningAsync();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.BackColor == SystemColors.Window)
            {
                darkModeAc();
            }
            else
            {
                darkModeKapat();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string finetuningModelId = textBox6.Text;
            modelDurumAsync(finetuningModelId);

            if (status == "succeeded")
            {
                useModelAsync();
            }
            else if (status == "pending")
            {
                MessageBox.Show("FineTune modeli hâlâ beklemede tekrar deneyiniz\n (Try again, FineTunel model status still pending )");
            }
        }
        private async Task fineTuningAsync()
        {
            string purpose = "fine-tune";

            using (HttpClient filesClient = new HttpClient())
            {
                filesClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                using (MultipartFormDataContent filesContent = new MultipartFormDataContent())
                {
                    using (FileStream fileStream = File.OpenRead(filePath))
                    {
                        filesContent.Add(new StreamContent(fileStream), "file", Path.GetFileName(filePath));
                        filesContent.Add(new StringContent(purpose), "purpose");

                        using (HttpResponseMessage filesResponse = await filesClient.PostAsync(filesUrl, filesContent))
                        {
                            if (filesResponse.IsSuccessStatusCode)
                            {
                                string filesResult = await filesResponse.Content.ReadAsStringAsync();
                                dynamic filesJson = Newtonsoft.Json.JsonConvert.DeserializeObject(filesResult);
                                string fileId = filesJson.id;

                                string model = "ada";
                                string suffix = "riku-testing";

                                using (HttpClient fineTunesClient = new HttpClient())
                                {
                                    fineTunesClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                                    string json = $"{{\"training_file\":\"{fileId}\",\"model\":\"{model}\",\"suffix\":\"{suffix}\"}}";

                                    using (StringContent fineTunesContent = new StringContent(json, Encoding.UTF8, "application/json"))
                                    {
                                        using (HttpResponseMessage fineTunesResponse = await fineTunesClient.PostAsync(fineTunesUrl, fineTunesContent))
                                        {
                                            if (fineTunesResponse.IsSuccessStatusCode)
                                            {
                                                string fineTunesResult = await fineTunesResponse.Content.ReadAsStringAsync();
                                                dynamic modelInfo = Newtonsoft.Json.JsonConvert.DeserializeObject(fineTunesResult);
                                                textBox4.Text = modelInfo.id;
                                                MessageBox.Show($"File id : {fileId}\n FinetuneModel: {modelInfo}");
                                            }
                                            else
                                            {
                                                MessageBox.Show($"{fineTunesResponse.StatusCode}: {fineTunesResponse.ReasonPhrase}");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show($"{filesResponse.StatusCode}: {filesResponse.ReasonPhrase}");
                            }
                        }
                    }
                }
            }
        }
        private async Task useModelAsync()
        {
            string question = textBox1.Text;
            fineTunedModelId = textBox5.Text;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                string apiUrl = "https://api.openai.com/v1/engines/" + fineTunedModelId + "/completions";

                string requestBody = $"{{\"prompt\": \"{question}\", \"max_tokens\": 50}}";
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    dynamic parsedJson = JObject.Parse(responseContent);
                    textBox2.Text = parsedJson.choices[0].text;
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}");
                }
            }



        }
        private async Task modelDurumAsync(string finetuneId)
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.openai.com/v1/fine-tunes/" + finetuneId);
            request.Headers.Add("Authorization", "Bearer " + apiKey);
            var response = await client.SendAsync(request);
            string result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                dynamic modelInfo = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                status = modelInfo.status;
                
            }
            else
            {
                MessageBox.Show($"Error: {response.StatusCode}");
            }

        }
        private void darkModeAc()
        {
            this.BackColor = System.Drawing.Color.Gray;
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = SystemColors.Window;

            textBox2.BackColor = Color.Black;
            textBox2.ForeColor = SystemColors.Window;
        }
        private void darkModeKapat()
        {
            this.BackColor = SystemColors.Control;
            textBox1.BackColor = SystemColors.Window;
            textBox1.ForeColor = Color.Black;

            textBox2.BackColor = SystemColors.Window;
            textBox2.ForeColor = Color.Black;
        }


    }
}