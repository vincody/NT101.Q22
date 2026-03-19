namespace ClassicalCryptographyApp.Forms
{
    partial class MonoCipher
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
            rtbInput = new RichTextBox();
            btnLoadFile = new Button();
            btnNormalize = new Button();
            rtbOutput = new RichTextBox();
            btnDecrypt = new Button();
            lblScore = new Label();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            txtCurrentKey = new TextBox();
            numericUpDown2 = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // rtbInput
            // 
            rtbInput.Location = new Point(12, 74);
            rtbInput.Name = "rtbInput";
            rtbInput.Size = new Size(776, 235);
            rtbInput.TabIndex = 0;
            rtbInput.Text = "";
            // 
            // btnLoadFile
            // 
            btnLoadFile.Location = new Point(12, 18);
            btnLoadFile.Name = "btnLoadFile";
            btnLoadFile.Size = new Size(75, 50);
            btnLoadFile.TabIndex = 1;
            btnLoadFile.Text = "Load file";
            btnLoadFile.UseVisualStyleBackColor = true;
            btnLoadFile.Click += btnLoadFile_Click;
            // 
            // btnNormalize
            // 
            btnNormalize.Location = new Point(93, 18);
            btnNormalize.Name = "btnNormalize";
            btnNormalize.Size = new Size(135, 50);
            btnNormalize.TabIndex = 2;
            btnNormalize.Text = "Chuan hoa van ban";
            btnNormalize.UseVisualStyleBackColor = true;
            btnNormalize.Click += btnNormalize_Click;
            // 
            // rtbOutput
            // 
            rtbOutput.Location = new Point(12, 358);
            rtbOutput.Name = "rtbOutput";
            rtbOutput.Size = new Size(776, 275);
            rtbOutput.TabIndex = 3;
            rtbOutput.Text = "";
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(690, 4);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(98, 64);
            btnDecrypt.TabIndex = 4;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(626, 45);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(38, 15);
            lblScore.TabIndex = 5;
            lblScore.Text = "label1";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(234, 45);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(262, 27);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 7;
            label1.Text = "Số lần lặp";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(440, 10);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(244, 23);
            progressBar1.TabIndex = 8;
            // 
            // txtCurrentKey
            // 
            txtCurrentKey.Location = new Point(12, 321);
            txtCurrentKey.Name = "txtCurrentKey";
            txtCurrentKey.Size = new Size(342, 23);
            txtCurrentKey.TabIndex = 9;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(360, 45);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.ValueChanged += nudRestarts_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(375, 27);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 11;
            label2.Text = "Số lần chạy lại";
            // 
            // MonoCipher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 645);
            Controls.Add(label2);
            Controls.Add(numericUpDown2);
            Controls.Add(txtCurrentKey);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(lblScore);
            Controls.Add(btnDecrypt);
            Controls.Add(rtbOutput);
            Controls.Add(btnNormalize);
            Controls.Add(btnLoadFile);
            Controls.Add(rtbInput);
            Name = "MonoCipher";
            Text = "MonoCipher";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbInput;
        private Button btnLoadFile;
        private Button btnNormalize;
        private RichTextBox rtbOutput;
        private Button btnDecrypt;
        private Label lblScore;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private ProgressBar progressBar1;
        private TextBox txtCurrentKey;
        private NumericUpDown numericUpDown2;
        private Label label2;
    }
}