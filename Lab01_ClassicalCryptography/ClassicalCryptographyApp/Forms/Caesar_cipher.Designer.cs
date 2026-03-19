namespace ClassicalCryptographyApp.Forms
{
    partial class Caesar_cipher
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
            rtbTruoc = new RichTextBox();
            rtbSau = new RichTextBox();
            label1 = new Label();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            tbKey = new TextBox();
            label2 = new Label();
            btnBruteForce = new Button();
            SuspendLayout();
            // 
            // rtbTruoc
            // 
            rtbTruoc.Location = new Point(12, 157);
            rtbTruoc.Name = "rtbTruoc";
            rtbTruoc.Size = new Size(395, 281);
            rtbTruoc.TabIndex = 0;
            rtbTruoc.Text = "";
            // 
            // rtbSau
            // 
            rtbSau.Location = new Point(413, 157);
            rtbSau.Name = "rtbSau";
            rtbSau.Size = new Size(375, 281);
            rtbSau.TabIndex = 1;
            rtbSau.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(335, 28);
            label1.Name = "label1";
            label1.Size = new Size(141, 28);
            label1.TabIndex = 2;
            label1.Text = "Caesar Cipher";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(12, 33);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(164, 66);
            btnEncrypt.TabIndex = 3;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(639, 33);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(149, 66);
            btnDecrypt.TabIndex = 4;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // tbKey
            // 
            tbKey.Location = new Point(44, 128);
            tbKey.Name = "tbKey";
            tbKey.Size = new Size(169, 23);
            tbKey.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 131);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 6;
            label2.Text = "Key";
            // 
            // btnBruteForce
            // 
            btnBruteForce.Location = new Point(362, 76);
            btnBruteForce.Name = "btnBruteForce";
            btnBruteForce.Size = new Size(102, 70);
            btnBruteForce.TabIndex = 7;
            btnBruteForce.Text = "Brute Force";
            btnBruteForce.UseVisualStyleBackColor = true;
            btnBruteForce.Click += btnBruteForce_Click;
            // 
            // Caesar_cipher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBruteForce);
            Controls.Add(label2);
            Controls.Add(tbKey);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(label1);
            Controls.Add(rtbSau);
            Controls.Add(rtbTruoc);
            Name = "Caesar_cipher";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbTruoc;
        private RichTextBox rtbSau;
        private Label label1;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private TextBox tbKey;
        private Label label2;
        private Button btnBruteForce;
    }
}