using Newtonsoft.Json.Linq;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinetuningModel
{
    public partial class Form1 : Form
    {
        public string apiKey = "api key";
        string filesUrl = "https://api.openai.com/v1/files";
        string fineTunesUrl = "https://api.openai.com/v1/fine-tunes";

        string connectionString = "Data Source=DESKTOP-0AKH09M\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        SqlConnection connection;

        string filePath;
        string status;
        string fineTunedModelId;

        public Form1()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fineTunedModelId = textBox3.Text;
            stateKontrol();
            if (status == "succeeded")
            {
                useModelAsync();
            }
            else
            {
                MessageBox.Show("Status : pending");
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
        private void button3_Click(object sender, EventArgs e)
        {
            FineTunning form = new FineTunning();
            form.Show();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            modelEkle modelEkle = new modelEkle();
            modelEkle.Show();
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Form2 nesnesi oluþturuluyor
            form2.Show(); // Form2 gösteriliyor
            this.Hide(); // Form1 gizleniyor
        }
        private void modelButton_Click(object sender, EventArgs e)
        {
            FineTuneVeriTabaný form = new FineTuneVeriTabaný();
            form.Show();
            this.Hide();
        }


        private async Task useModelAsync()
        {
            string question = textBox1.Text;
            

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
        private void stateKontrol()
        {
            string query = $"SELECT status FROM FineTunedModels WHERE fineTunedModelId = @ModelId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ModelId", fineTunedModelId);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        status = result.ToString();
                       
                    }
                    else
                    {
                        
                    }
                }
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