namespace ClassicalCryptographyApp.Forms
{
    partial class VigenereED
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
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            tbKey = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            rtbDauVao = new RichTextBox();
            groupBox2 = new GroupBox();
            rtbDauRa = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(12, 12);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(144, 50);
            btnEncrypt.TabIndex = 1;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(162, 12);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(141, 50);
            btnDecrypt.TabIndex = 2;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // tbKey
            // 
            tbKey.Location = new Point(319, 27);
            tbKey.Name = "tbKey";
            tbKey.Size = new Size(643, 23);
            tbKey.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(319, 9);
            label1.Name = "label1";
            label1.Size = new Size(206, 15);
            label1.TabIndex = 4;
            label1.Text = "Nhap key o day (max 1024 characters)";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rtbDauVao);
            groupBox1.Location = new Point(12, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(956, 269);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dau vao";
            // 
            // rtbDauVao
            // 
            rtbDauVao.Location = new Point(16, 22);
            rtbDauVao.Name = "rtbDauVao";
            rtbDauVao.Size = new Size(923, 241);
            rtbDauVao.TabIndex = 0;
            rtbDauVao.Text = "";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtbDauRa);
            groupBox2.Location = new Point(12, 343);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(956, 275);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dau ra";
            // 
            // rtbDauRa
            // 
            rtbDauRa.Location = new Point(16, 22);
            rtbDauRa.Name = "rtbDauRa";
            rtbDauRa.Size = new Size(923, 247);
            rtbDauRa.TabIndex = 0;
            rtbDauRa.Text = "";
            // 
            // VigenereED
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 630);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(tbKey);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Name = "VigenereED";
            Text = "VigenereED";
            Load += VigenereED_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private TextBox tbKey;
        private Label label1;
        private GroupBox groupBox1;
        private RichTextBox rtbDauVao;
        private GroupBox groupBox2;
        private RichTextBox rtbDauRa;
    }
}