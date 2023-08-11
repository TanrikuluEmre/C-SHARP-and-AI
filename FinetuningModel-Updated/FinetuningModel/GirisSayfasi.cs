using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinetuningModel
{
    public partial class GirisSayfasi : Form
    {
        string connectionString = "Data Source=DESKTOP-0AKH09M\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
        SqlConnection connection;
        public GirisSayfasi()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            connection.Open();
            txtSifreOnay.Visible = false;
            labelSifreOnay.Visible = false;
            button1.Text = "Giriş Yap";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (txtSifreOnay.Visible)
            {
                if (txtPassword.Text == txtSifreOnay.Text)
                {
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;

                    string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kayıt başarıyla tamamlandı.");
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor!");
                }
            }
            else
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                string selectQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int userCount = (int)cmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Giriş başarılı.");
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelKayit_Click(object sender, EventArgs e)
        {
            if (txtSifreOnay.Visible)
            {
                txtSifreOnay.Visible = false;
                labelSifreOnay.Visible = false;
                button1.Text = "Giriş Yap";
                labelKayit.Text = "Hesabınız yok mu? Kayıt olmak için tıklayınız.";
                labelKayit.Location = new Point(54, 331);

            }
            else
            {
                txtSifreOnay.Visible = true;
                labelSifreOnay.Visible = true;
                button1.Text = "Kayıt Ol";
                labelKayit.Text = "Giriş yapmak için tıklayınız.";
                labelKayit.Location = new Point(109, 334);
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                txtSifreOnay.PasswordChar = '\0';
                radioButton1.Checked = true;

            }
            else
            {

                txtPassword.PasswordChar = '*';
                txtSifreOnay.PasswordChar = '*';
                radioButton1.Checked = false;
            }

        }
    }
}