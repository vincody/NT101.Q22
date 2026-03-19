using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassicalCryptographyApp.Forms
{
    public partial class ByteAddition : Form
    {
        public ByteAddition()
        {
            InitializeComponent();
        }
       

        private void ByteAddition_Load(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy Plaintext và chuyển thành mảng Byte (dùng UTF-8 để hỗ trợ tiếng Việt)
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(rtbDauVao.Text);

                // 2. Parse Key từ dạng Hex (Ví dụ: AF) thành giá trị số (0-255)
                byte key = byte.Parse(tbKey.Text, System.Globalization.NumberStyles.HexNumber);

                // 3. Thực hiện thuật toán Byte Addition: C = (P + K) mod 256
                byte[] ciphertextBytes = new byte[plaintextBytes.Length];
                for (int i = 0; i < plaintextBytes.Length; i++)
                {
                    ciphertextBytes[i] = (byte)((plaintextBytes[i] + key) % 256);
                }

                // 4. HIỂN THỊ: Chuyển mảng byte nhị phân thành chuỗi Base64 để an toàn
                rtbDauRa.Text = Convert.ToBase64String(ciphertextBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mã hóa! Hãy chắc chắn Key là dạng Hex (0-9, A-F).\nChi tiết: " + ex.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. NHẬN DỮ LIỆU: Đầu vào là chuỗi Base64 (bản mã an toàn)
                byte[] ciphertextBytes = Convert.FromBase64String(rtbDauVao.Text);

                // 2. Parse Key từ dạng Hex
                byte key = byte.Parse(tbKey.Text, System.Globalization.NumberStyles.HexNumber);

                // 3. Thực hiện thuật toán Giải mã: P = (C - K + 256) mod 256
                byte[] decryptedBytes = new byte[ciphertextBytes.Length];
                for (int i = 0; i < ciphertextBytes.Length; i++)
                {
                    decryptedBytes[i] = (byte)((ciphertextBytes[i] - key + 256) % 256);
                }

                // 4. HIỂN THỊ: Chuyển mảng byte đã giải mã về văn bản đọc được (UTF-8)
                rtbDauRa.Text = Encoding.UTF8.GetString(decryptedBytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi giải mã! Hãy chắc chắn đầu vào là chuỗi Base64 hợp lệ và Key đúng dạng Hex.\nChi tiết: " + ex.Message);
            }
        }


    }
}
