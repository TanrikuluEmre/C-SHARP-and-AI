namespace FinetuningModel
{
    partial class GirisSayfasi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            label3 = new Label();
            labelKayit = new Label();
            txtSifreOnay = new TextBox();
            labelSifreOnay = new Label();
            radioButton1 = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 183);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Şifre :";
            // 
            // button1
            // 
            button1.Location = new Point(147, 284);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(116, 130);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(172, 27);
            txtUsername.TabIndex = 3;
            txtUsername.TextChanged += textBox1_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(116, 180);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(172, 27);
            txtPassword.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 133);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 6;
            label2.Text = "Kullanıcı Adı :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(70, 53);
            label3.Name = "label3";
            label3.Size = new Size(256, 37);
            label3.TabIndex = 7;
            label3.Text = "SOLON SOFTWARE";
            // 
            // labelKayit
            // 
            labelKayit.AutoSize = true;
            labelKayit.Cursor = Cursors.Hand;
            labelKayit.Font = new Font("Segoe UI", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
            labelKayit.Location = new Point(67, 335);
            labelKayit.Name = "labelKayit";
            labelKayit.Size = new Size(281, 19);
            labelKayit.TabIndex = 8;
            labelKayit.Text = "Hesabınız yok mu? Kayıt olmak için tıklayınız.";
            labelKayit.TextAlign = ContentAlignment.TopCenter;
            labelKayit.Click += labelKayit_Click;
            // 
            // txtSifreOnay
            // 
            txtSifreOnay.Location = new Point(116, 234);
            txtSifreOnay.Margin = new Padding(3, 4, 3, 4);
            txtSifreOnay.Name = "txtSifreOnay";
            txtSifreOnay.PasswordChar = '*';
            txtSifreOnay.Size = new Size(172, 27);
            txtSifreOnay.TabIndex = 10;
            // 
            // labelSifreOnay
            // 
            labelSifreOnay.AutoSize = true;
            labelSifreOnay.Location = new Point(14, 237);
            labelSifreOnay.Name = "labelSifreOnay";
            labelSifreOnay.Size = new Size(84, 20);
            labelSifreOnay.TabIndex = 9;
            labelSifreOnay.Text = "Şifre Onay :";
            // 
            // radioButton1
            // 
            radioButton1.AutoCheck = false;
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            radioButton1.Location = new Point(250, 284);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 16);
            radioButton1.TabIndex = 11;
            radioButton1.TabStop = true;
            radioButton1.Text = "Şifreyi Görüntüle";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Click += radioButton1_Click;
            // 
            // GirisSayfasi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 425);
            Controls.Add(radioButton1);
            Controls.Add(txtSifreOnay);
            Controls.Add(labelSifreOnay);
            Controls.Add(labelKayit);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(button1);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GirisSayfasi";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label2;
        private Label label3;
        private Label labelKayit;
        private TextBox txtSifreOnay;
        private Label labelSifreOnay;
        private RadioButton radioButton1;
    }
}