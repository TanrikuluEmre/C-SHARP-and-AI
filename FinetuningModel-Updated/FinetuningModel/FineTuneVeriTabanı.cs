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

namespace FinetuningModel
{
    public partial class FineTuneVeriTabanı : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        string connectionString = "Data Source=DESKTOP-0AKH09M\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        public FineTuneVeriTabanı()
        {

            InitializeComponent();
        }

        private void FineTuneVeriTabanı_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionString);

            // SQL sorgusu
            string query = "SELECT * FROM FineTunedModels";

            // SqlDataAdapter oluşturun
            adapter = new SqlDataAdapter(query, connection);

            // DataTable oluşturun
            dataTable = new DataTable();

            // Verileri çekin ve DataTable'a yükleyin
            adapter.Fill(dataTable);

            // DataGridView'e veri kaynağını bağlayın
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            adapter.Fill(dataTable);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
