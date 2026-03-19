namespace ClassicalCryptographyApp.Forms
{
    partial class ByteAddition
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
            rtbDauVao = new RichTextBox();
            rtbDauRa = new RichTextBox();
            tbKey = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // rtbDauVao
            // 
            rtbDauVao.Location = new Point(12, 12);
            rtbDauVao.Name = "rtbDauVao";
            rtbDauVao.Size = new Size(892, 194);
            rtbDauVao.TabIndex = 0;
            rtbDauVao.Text = "";
            // 
            // rtbDauRa
            // 
            rtbDauRa.Location = new Point(12, 244);
            rtbDauRa.Name = "rtbDauRa";
            rtbDauRa.Size = new Size(892, 194);
            rtbDauRa.TabIndex = 1;
            rtbDauRa.Text = "";
            // 
            // tbKey
            // 
            tbKey.Location = new Point(327, 476);
            tbKey.Name = "tbKey";
            tbKey.Size = new Size(567, 23);
            tbKey.TabIndex = 2;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(12, 444);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(147, 85);
            btnEncrypt.TabIndex = 3;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(165, 444);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(147, 85);
            btnDecrypt.TabIndex = 4;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(327, 458);
            label1.Name = "label1";
            label1.Size = new Size(216, 15);
            label1.TabIndex = 5;
            label1.Text = "Enter the key using character [0.9 - A..F]";
            // 
            // ByteAddition
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 541);
            Controls.Add(label1);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(tbKey);
            Controls.Add(rtbDauRa);
            Controls.Add(rtbDauVao);
            Name = "ByteAddition";
            Text = "Byte Additions";
            Load += ByteAddition_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbDauVao;
        private RichTextBox rtbDauRa;
        private TextBox tbKey;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label label1;
    }
}