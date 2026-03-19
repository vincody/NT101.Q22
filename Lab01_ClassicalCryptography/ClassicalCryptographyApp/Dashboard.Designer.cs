namespace ClassicalCryptographyApp
{
    partial class Dashboard
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
            buttonCaesar = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            buttonVigenere = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // buttonCaesar
            // 
            buttonCaesar.Location = new Point(30, 119);
            buttonCaesar.Name = "buttonCaesar";
            buttonCaesar.Size = new Size(140, 68);
            buttonCaesar.TabIndex = 0;
            buttonCaesar.Text = "Ceasar ";
            buttonCaesar.UseVisualStyleBackColor = true;
            buttonCaesar.Click += buttonCaesar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(200, 119);
            button2.Name = "button2";
            button2.Size = new Size(142, 68);
            button2.TabIndex = 1;
            button2.Text = "Mono cipher";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(387, 119);
            button3.Name = "button3";
            button3.Size = new Size(152, 68);
            button3.TabIndex = 2;
            button3.Text = "Playfair";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(225, 34);
            label1.Name = "label1";
            label1.Size = new Size(355, 46);
            label1.TabIndex = 3;
            label1.Text = "LAB1: Mật mã cổ điển ";
            // 
            // buttonVigenere
            // 
            buttonVigenere.Location = new Point(593, 119);
            buttonVigenere.Name = "buttonVigenere";
            buttonVigenere.Size = new Size(152, 68);
            buttonVigenere.TabIndex = 4;
            buttonVigenere.Text = "Vignere";
            buttonVigenere.UseVisualStyleBackColor = true;
            buttonVigenere.Click += buttonVigenere_Click;
            // 
            // button1
            // 
            button1.Location = new Point(30, 228);
            button1.Name = "button1";
            button1.Size = new Size(152, 68);
            button1.TabIndex = 5;
            button1.Text = "Byte Additions";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(buttonVigenere);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(buttonCaesar);
            Name = "Dashboard";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCaesar;
        private Button button2;
        private Button button3;
        private Label label1;
        private Button buttonVigenere;
        private Button button1;
    }
}
