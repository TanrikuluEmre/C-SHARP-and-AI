namespace FinetuningModel
{
    partial class modelEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            button1 = new Button();
            pathOfFile = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(85, 22);
            label3.Name = "label3";
            label3.Size = new Size(178, 37);
            label3.TabIndex = 11;
            label3.Text = "MODEL EKLE";
            // 
            // button1
            // 
            button1.Location = new Point(97, 134);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(149, 31);
            button1.TabIndex = 10;
            button1.Text = "Gönder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pathOfFile
            // 
            pathOfFile.Location = new Point(56, 85);
            pathOfFile.Margin = new Padding(3, 4, 3, 4);
            pathOfFile.Name = "pathOfFile";
            pathOfFile.Size = new Size(234, 27);
            pathOfFile.TabIndex = 9;
            pathOfFile.Text = "Model Id";
            pathOfFile.TextChanged += pathOfFile_TextChanged;
            // 
            // modelEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 253);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(pathOfFile);
            Name = "modelEkle";
            Text = "modelEkle";
            Load += modelEkle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Button button1;
        private TextBox pathOfFile;
    }
}