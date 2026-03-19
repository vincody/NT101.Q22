using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassicalCryptographyApp.Forms
{
    public partial class Caesar_cipher : Form
    {
        public Caesar_cipher()
        {
            InitializeComponent();
        }
        private string CaesarProcess(string text, int key)
        {
            char[] buffer = text.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                if (char.IsLetter(letter))
                {
                    char offset = char.IsUpper(letter) ? 'A' : 'a';
                    // Áp dụng công thức và đảm bảo kết quả luôn dương
                    buffer[i] = (char)((((letter + key) - offset) % 26 + 26) % 26 + offset);
                }
            }
            return new string(buffer);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbKey.Text, out int key))
            {
                rtbSau.Text = CaesarProcess(rtbTruoc.Text, key);
            }
            else { MessageBox.Show("Vui lòng nhập Key là số nguyên!"); }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbKey.Text, out int key))
            {
                // Giải mã là mã hóa với khóa âm
                rtbSau.Text = CaesarProcess(rtbTruoc.Text, -key);
            }
            else { MessageBox.Show("Vui lòng nhập Key là số nguyên!"); }
        }

        private void btnBruteForce_Click(object sender, EventArgs e)
        {
            string cipherText = rtbTruoc.Text;
            string results = "";

            for (int k = 1; k < 26; k++)
            {
                string decoded = CaesarProcess(cipherText, -k);
                results += $"[Key {k}]: {decoded}\n\n";
            }
            rtbSau.Text = results;
        }
    }
}
