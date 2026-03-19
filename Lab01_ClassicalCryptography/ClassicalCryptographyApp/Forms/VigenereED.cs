using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClassicalCryptographyApp.Forms
{
    public partial class VigenereED : Form
    {
        public VigenereED()
        {
            InitializeComponent();
        }

        private void VigenereED_Load(object sender, EventArgs e)
        {

        }
        // Bảng tần suất chữ cái tiếng Anh chuẩn (để phá mã)
        private readonly double[] englishFreq = {
            0.0817, 0.0149, 0.0278, 0.0425, 0.1270, 0.0223, 0.0202, 0.0609, 0.0697,
            0.0015, 0.0077, 0.0403, 0.0241, 0.0675, 0.0751, 0.0193, 0.0010, 0.0599,
            0.0633, 0.0906, 0.0276, 0.0098, 0.0236, 0.0015, 0.0197, 0.0007
        };
        // --- HÀM TRỢ GIÚP ---
        private string Normalize(string input)
        {
            return new string(input.ToUpper().Where(char.IsLetter).ToArray());
        }

        private double CalculateIC(string text)
        {
            if (text.Length <= 1) return 0;
            int[] counts = new int[26];
            foreach (char c in text) counts[c - 'A']++;
            double ic = 0;
            foreach (int count in counts) ic += (double)count * (count - 1);
            return ic / (text.Length * (text.Length - 1));
        }

        // --- LOGIC CHÍNH: MÃ HÓA / GIẢI MÃ (GIỮ ĐỊNH DẠNG) ---
        private string VigenereProcess(string input, string key, bool isEncrypt)
        {
            string cleanKey = Normalize(key);
            if (string.IsNullOrEmpty(cleanKey)) return "Lỗi: Khóa không hợp lệ!";

            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char p = input[i];
                if (char.IsLetter(p))
                {
                    bool isLower = char.IsLower(p);
                    int pi = char.ToUpper(p) - 'A';
                    int ki = cleanKey[keyIndex % cleanKey.Length] - 'A';

                    int resPos = isEncrypt ? (pi + ki) % 26 : (pi - ki + 26) % 26;
                    char resChar = (char)(resPos + 'A');

                    result.Append(isLower ? char.ToLower(resChar) : resChar);
                    keyIndex++;
                }
                else
                {
                    result.Append(p); // Giữ nguyên Space, xuống dòng, dấu câu
                }
            }
            return result.ToString();
        }

        // --- LOGIC NÂNG CAO: TỰ ĐỘNG PHÁ MÃ (KHÔNG CẦN KEY) ---
        private void AutoAttackVigenere()
        {
            string ciphertext = rtbDauVao.Text;
            string clean = Normalize(ciphertext);
            if (clean.Length < 30)
            {
                MessageBox.Show("Văn bản quá ngắn để phân tích thống kê tự động!");
                return;
            }

            // 1. Tìm độ dài khóa (Key Length) bằng Index of Coincidence
            int bestLength = 1;
            double maxIC = 0;
            for (int len = 1; len <= 20; len++)
            {
                double avgIC = 0;
                for (int i = 0; i < len; i++)
                {
                    StringBuilder sub = new StringBuilder();
                    for (int j = i; j < clean.Length; j += len) sub.Append(clean[j]);
                    avgIC += CalculateIC(sub.ToString());
                }
                avgIC /= len;
                if (avgIC > maxIC) { maxIC = avgIC; bestLength = len; }
            }

            // 2. Tìm từng ký tự Key bằng Chi-Squared Frequency Analysis
            StringBuilder foundKey = new StringBuilder();
            for (int i = 0; i < bestLength; i++)
            {
                List<char> subGroup = new List<char>();
                for (int j = i; j < clean.Length; j += bestLength) subGroup.Add(clean[j]);

                int bestShift = 0;
                double minChiSq = double.MaxValue;

                for (int shift = 0; shift < 26; shift++)
                {
                    double chiSq = 0;
                    int[] counts = new int[26];
                    foreach (char c in subGroup) counts[(c - 'A' - shift + 26) % 26]++;

                    for (int k = 0; k < 26; k++)
                    {
                        double expected = subGroup.Count * englishFreq[k];
                        chiSq += Math.Pow(counts[k] - expected, 2) / (expected > 0 ? expected : 1);
                    }
                    if (chiSq < minChiSq) { minChiSq = chiSq; bestShift = shift; }
                }
                foundKey.Append((char)(bestShift + 'A'));
            }

            // 3. Hiển thị kết quả
            tbKey.Text = foundKey.ToString();
            rtbDauRa.Text = VigenereProcess(ciphertext, foundKey.ToString(), false);
            MessageBox.Show($"Đã tìm thấy khóa: {foundKey}");
        }

        // --- SỰ KIỆN NÚT BẤM ---
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbKey.Text))
            {
                MessageBox.Show("Vui lòng nhập Key để mã hóa!");
                return;
            }
            rtbDauRa.Text = VigenereProcess(rtbDauVao.Text, tbKey.Text, true);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            // Nếu không có Key -> Chế độ Phá mã tự động (Nhiệm vụ 2.6)
            if (string.IsNullOrWhiteSpace(tbKey.Text))
            {
                AutoAttackVigenere();
            }
            else // Nếu có Key -> Giải mã bình thường (Nhiệm vụ 2.5)
            {
                rtbDauRa.Text = VigenereProcess(rtbDauVao.Text, tbKey.Text, false);
            }
        }
    }
}
