namespace FinetuningModel
{
    partial class FineTunning
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
            pathOfFile = new TextBox();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // pathOfFile
            // 
            pathOfFile.Location = new Point(55, 64);
            pathOfFile.Margin = new Padding(3, 4, 3, 4);
            pathOfFile.Name = "pathOfFile";
            pathOfFile.Size = new Size(234, 27);
            pathOfFile.TabIndex = 6;
            pathOfFile.Text = "Dosya Yolu";
            // 
            // button1
            // 
            button1.Location = new Point(96, 113);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(149, 31);
            button1.TabIndex = 7;
            button1.Text = "Gönder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(73, 9);
            label3.Name = "label3";
            label3.Size = new Size(188, 37);
            label3.TabIndex = 8;
            label3.Text = "FINE TUNING";
            // 
            // FineTunning
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 186);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(pathOfFile);
            Name = "FineTunning";
            Text = "FineTunning";
            Load += FineTunning_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox pathOfFile;
        private Button button1;
        private Label label3;
    }
}