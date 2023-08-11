namespace FinetuningModel
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button6 = new Button();
            modelButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            textBox3 = new TextBox();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 205);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(886, 139);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 488);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(886, 139);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(398, 397);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(149, 31);
            button1.TabIndex = 2;
            button1.Text = "Gönder";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(815, 16);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(86, 31);
            button2.TabIndex = 3;
            button2.Text = "DarkMode";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(14, 13);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(149, 31);
            button3.TabIndex = 4;
            button3.Text = "FineTuning";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button6
            // 
            button6.Location = new Point(279, 13);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(86, 31);
            button6.TabIndex = 11;
            button6.Text = "ChatGPT";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // modelButton
            // 
            modelButton.Location = new Point(371, 13);
            modelButton.Margin = new Padding(3, 4, 3, 4);
            modelButton.Name = "modelButton";
            modelButton.Size = new Size(86, 31);
            modelButton.TabIndex = 13;
            modelButton.Text = "Modeller";
            modelButton.UseVisualStyleBackColor = true;
            modelButton.Click += modelButton_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // textBox3
            // 
            textBox3.Location = new Point(14, 171);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(174, 27);
            textBox3.TabIndex = 14;
            textBox3.Text = "fine_tuned_model giriniz";
            // 
            // button4
            // 
            button4.Location = new Point(169, 13);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(104, 31);
            button4.TabIndex = 15;
            button4.Text = "Model Ekle";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(914, 665);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(modelButton);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "-";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button5;
        private Button button6;
        private Button modelButton;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private TextBox textBox3;
        private Button button4;
    }
}