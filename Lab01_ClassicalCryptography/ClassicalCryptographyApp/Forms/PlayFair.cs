using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassicalCryptographyApp.Forms
{
    public partial class PlayFair : Form
    {
        private TextBox[,] matrixCells = new TextBox[5, 5];
        private char[,] keyMatrix = new char[5, 5];
        public PlayFair()
        {
            InitializeComponent();
            CreateMatrixUI();
            tbKey.TextChanged += (s, e) => UpdateMatrix();
        }
        // Tạo 25 TextBox hiển thị ma trận trong groupBox3
        private void CreateMatrixUI()
        {
            groupBox3.Controls.Clear();
            int cellSize = 30;
            int margin = 5;

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    var txt = new TextBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Location = new Point(margin + c * (cellSize + 5), margin + 20 + r * (cellSize + 5)),
                        TextAlign = HorizontalAlignment.Center,
                        ReadOnly = true,
                        BackColor = Color.White
                    };
                    matrixCells[r, c] = txt;
                    groupBox3.Controls.Add(txt);
                }
            }
            UpdateMatrix(); // Khởi tạo ma trận mặc định (A-Z, bỏ J)
        }
        // Logic tạo ma trận từ Key
        private void UpdateMatrix()
        {
            string key = tbKey.Text.ToUpper().Replace("J", "I");
            string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; // Không có J

            string combined = new string((key + alphabet).Distinct().ToArray());

            for (int i = 0; i < 25; i++)
            {
                int r = i / 5;
                int c = i % 5;
                keyMatrix[r, c] = combined[i];
                matrixCells[r, c].Text = combined[i].ToString();
            }
        }
        // Chuẩn hóa văn bản theo quy tắc Playfair (Xử lý cặp trùng, thêm X lẻ)
        private string PrepareText(string input, bool forEncrypt)
        {
            string text = new string(input.ToUpper().Where(char.IsLetter).ToArray()).Replace("J", "I");
            if (!forEncrypt) return text;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append(text[i]);
                if (i + 1 < text.Length)
                {
                    if (text[i] == text[i + 1]) sb.Append('X'); // Separate duplicate
                }
            }
            if (sb.Length % 2 != 0) sb.Append('X'); // Pad if odd
            return sb.ToString();
        }

        private (int r, int c) FindPos(char ch)
        {
            for (int r = 0; r < 5; r++)
                for (int c = 0; c < 5; c++)
                    if (keyMatrix[r, c] == ch) return (r, c);
            return (0, 0);
        }

        private string Process(string input, int direction) // direction: 1 for encrypt, 4 for decrypt
        {
            string text = PrepareText(input, direction == 1);
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < text.Length; i += 2)
            {
                var p1 = FindPos(text[i]);
                var p2 = FindPos(text[i + 1]);

                if (p1.r == p2.r) // Cùng hàng
                {
                    output.Append(keyMatrix[p1.r, (p1.c + direction) % 5]);
                    output.Append(keyMatrix[p2.r, (p2.c + direction) % 5]);
                }
                else if (p1.c == p2.c) // Cùng cột
                {
                    output.Append(keyMatrix[(p1.r + direction) % 5, p1.c]);
                    output.Append(keyMatrix[(p2.r + direction) % 5, p2.c]);
                }
                else // Hình chữ nhật
                {
                    output.Append(keyMatrix[p1.r, p2.c]);
                    output.Append(keyMatrix[p2.r, p1.c]);
                }
            }
            return output.ToString();
        }

        private void PlayFair_Load(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            rtbHienThi.Text = Process(rtbHienThi.Text, 1);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            rtbHienThi.Text = Process(rtbHienThi.Text, 4); // +4 tương đương -1 mod 5
        }
    }
}
