using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinetuningModel
{
    public partial class FineTunning : Form
    {
        public string apiKey = "api key";
        string filesUrl = "https://api.openai.com/v1/files";
        string fineTunesUrl = "https://api.openai.com/v1/fine-tunes";
        string connectionString = "Data Source=DESKTOP-0AKH09M\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        SqlConnection connection;
        string filePath;
        public FineTunning()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filePath = pathOfFile.Text;
            if (filePath == null)
            {
                MessageBox.Show("filepath is null");
            }
            else
            {
                fineTuningAsync();
            }
        }
        public async Task fineTuningAsync()
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

                                                string fine_tuned_model = $"{modelInfo.fine_tuned_model}";
                                                string id = modelInfo.id;
                                                string finetunemodel = modelInfo.model;
                                                string status = modelInfo.status;

                                                string insertQuery = "INSERT INTO FineTunedModels (ModelId, model, status, fine_tuned_model) VALUES (@ModelId, @model, @status, @fine_tuned_model)";
                                                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                                                {
                                                    cmd.Parameters.AddWithValue("@ModelId", id);
                                                    cmd.Parameters.AddWithValue("@model", finetunemodel);
                                                    cmd.Parameters.AddWithValue("@status", status);
                                                    cmd.Parameters.AddWithValue("@fine_tuned_model", fine_tuned_model);
                                                    cmd.ExecuteNonQuery();
                                                }
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

        private void FineTunning_Load(object sender, EventArgs e)
        {

        }
    }
}
