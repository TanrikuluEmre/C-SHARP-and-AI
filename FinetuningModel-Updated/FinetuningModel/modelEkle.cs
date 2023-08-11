using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinetuningModel
{
    public partial class modelEkle : Form
    {
        string connectionString = "Data Source=DESKTOP-0AKH09M\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        SqlConnection connection;
        public string apiKey = "api key";
        string fineTunedModelId;
        string status;
        public modelEkle()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modelDurumAsync();
        }
        private async Task modelDurumAsync()
        {
            fineTunedModelId = pathOfFile.Text;
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.openai.com/v1/fine-tunes/" + fineTunedModelId);
            request.Headers.Add("Authorization", "Bearer "+apiKey);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string fineTunesResult = await response.Content.ReadAsStringAsync();
                dynamic modelInfo = Newtonsoft.Json.JsonConvert.DeserializeObject(fineTunesResult);

                string id = modelInfo.id;
                string finetunemodel = modelInfo.model;
                string status = modelInfo.status;
                string fine_tuned_model = $"{modelInfo.fine_tuned_model}";

                // Check if the model already exists in the database
                string selectQuery = "SELECT COUNT(*) FROM FineTunedModels WHERE ModelId = @ModelId";
                using (SqlCommand selectCmd = new SqlCommand(selectQuery, connection))
                {
                    selectCmd.Parameters.AddWithValue("@ModelId", id);
                    int existingRowCount = (int)selectCmd.ExecuteScalar();

                    if (existingRowCount > 0)
                    {
                        // Update the existing record
                        string updateQuery = "UPDATE FineTunedModels SET model = @model, status = @status, fine_tuned_model = @fine_tuned_model WHERE ModelId = @ModelId";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                        {
                            updateCmd.Parameters.AddWithValue("@ModelId", id);
                            updateCmd.Parameters.AddWithValue("@model", finetunemodel);
                            updateCmd.Parameters.AddWithValue("@status", status);
                            updateCmd.Parameters.AddWithValue("@fine_tuned_model", fine_tuned_model);
                            updateCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Model güncellendi");
                    }
                    else
                    {
                        // Insert a new record
                        string insertQuery = "INSERT INTO FineTunedModels (ModelId, model, status, fine_tuned_model) VALUES (@ModelId, @model, @status, @fine_tuned_model)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@ModelId", id);
                            insertCmd.Parameters.AddWithValue("@model", finetunemodel);
                            insertCmd.Parameters.AddWithValue("@status", status);
                            insertCmd.Parameters.AddWithValue("@fine_tuned_model", fine_tuned_model);
                            insertCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Model eklendi");
                    }
                }
            }
            else
            {
                MessageBox.Show($"Error: {response.StatusCode}");
            }
        }



        private void pathOfFile_TextChanged(object sender, EventArgs e)
        {   

        }

        private void modelEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
