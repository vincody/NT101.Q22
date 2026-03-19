namespace ClassicalCryptographyApp.Forms
{
    partial class PlayFair
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            tbKey = new TextBox();
            groupBox3 = new GroupBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            rtbHienThi = new RichTextBox();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 93);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(tbKey);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(12, 111);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(380, 327);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Playfair key";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 38);
            label1.Name = "label1";
            label1.Size = new Size(155, 15);
            label1.TabIndex = 3;
            label1.Text = "short verision of playfair key";
            // 
            // tbKey
            // 
            tbKey.Location = new Point(6, 56);
            tbKey.Name = "tbKey";
            tbKey.Size = new Size(355, 23);
            tbKey.TabIndex = 2;
            // 
            // groupBox3
            // 
            groupBox3.Location = new Point(6, 85);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(355, 223);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "key matrix";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(12, 444);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(177, 46);
            btnEncrypt.TabIndex = 2;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(195, 444);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(188, 46);
            btnDecrypt.TabIndex = 3;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // rtbHienThi
            // 
            rtbHienThi.Location = new Point(411, 12);
            rtbHienThi.Name = "rtbHienThi";
            rtbHienThi.Size = new Size(490, 478);
            rtbHienThi.TabIndex = 4;
            rtbHienThi.Text = "";
            // 
            // PlayFair
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(913, 502);
            Controls.Add(rtbHienThi);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "PlayFair";
            Text = "PlayFair";
            Load += PlayFair_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox tbKey;
        private GroupBox groupBox3;
        private Label label1;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private RichTextBox rtbHienThi;
    }
}