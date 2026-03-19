using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassicalCryptographyApp.Forms
{
    public partial class MonoCipher : Form
    {
        const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random rand = new Random();

        // Bộ từ điển Trigram và Bigram đánh giá điểm (Fitness)
        private readonly Dictionary<string, double> ngramScores = new Dictionary<string, double>
        {
            // Top English Trigrams
            {"THE", 3.5}, {"AND", 2.8}, {"ING", 2.7}, {"ENT", 2.6}, {"ION", 2.6},
            {"HER", 2.5}, {"FOR", 2.4}, {"THA", 2.3}, {"NTH", 2.2}, {"INT", 2.2},
            {"TIO", 2.1}, {"TER", 2.1}, {"EST", 2.0}, {"ERS", 2.0}, {"ATI", 1.9},
            {"HAT", 1.9}, {"ATE", 1.8}, {"ALL", 1.8}, {"ETH", 1.8}, {"HES", 1.7},
            {"VER", 1.7}, {"HIS", 1.7}, {"OFT", 1.7}, {"ITH", 1.6}, {"FRO", 1.6},
            {"RES", 1.6}, {"THI", 1.6}, {"ONT", 1.5}, {"ARE", 1.5}, {"ESS", 1.5},
            {"NOT", 1.5}, {"IVE", 1.5}, {"WAS", 1.5}, {"ECT", 1.4}, {"REA", 1.4},

            // Top English Bigrams
            {"TH", 1.5}, {"HE", 1.4}, {"IN", 1.3}, {"ER", 1.3}, {"AN", 1.2},
            {"RE", 1.2}, {"ND", 1.1}, {"ON", 1.1}, {"EN", 1.0}, {"AT", 1.0},
            {"OU", 1.0}, {"ED", 1.0}, {"HA", 0.9}, {"TO", 0.9}, {"OR", 0.9},
            {"IT", 0.9}, {"IS", 0.9}, {"HI", 0.8}, {"ES", 0.8}, {"NG", 0.8}
        };

        // Các cặp ký tự cực kỳ hiếm/không thể xuất hiện cạnh nhau trong tiếng Anh
        private readonly string[] illegalBigrams = {
            "CJ", "CQ", "CX", "FQ", "FX", "GQ", "GX", "HX", "JC", "JF", "JG", "JQ", "JS", "JV", "JW", "JX", "JZ",
            "KQ", "KX", "PQ", "PX", "QC", "QD", "QE", "QF", "QG", "QH", "QJ", "QK", "QL", "QM", "QN", "QP", "QR", "QS", "QT", "QV", "QW", "QX", "QY", "QZ",
            "SX", "TQ", "VQ", "VX", "WX", "XJ", "XX", "ZJ", "ZQ", "ZX"
        };

        public MonoCipher()
        {
            InitializeComponent();
            // Cài đặt giới hạn tìm kiếm (Stagnation)
            numericUpDown1.Minimum = 100;
            numericUpDown1.Maximum = 100000;
            numericUpDown1.Value = 5000; // Khuyến nghị: 2000 - 5000
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rtbInput.Text = File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void btnNormalize_Click(object sender, EventArgs e)
        {
            rtbInput.Text = Regex.Replace(rtbInput.Text.ToUpper(), "[^A-Z]", "");
        }

        private string FastDecrypt(string cipher, string key)
        {
            char[] output = new char[cipher.Length];
            for (int i = 0; i < cipher.Length; i++)
                output[i] = key[cipher[i] - 'A'];
            return new string(output);
        }

        private double CalculateFitness(string text)
        {
            double score = 0;
            if (text.Length < 4) return -10000;

            // Quét điểm Trigram
            for (int i = 0; i < text.Length - 2; i++)
            {
                string tri = text.Substring(i, 3);
                if (ngramScores.TryGetValue(tri, out double s)) score += s;
            }

            // Quét điểm Bigram
            for (int i = 0; i < text.Length - 1; i++)
            {
                string bi = text.Substring(i, 2);
                if (ngramScores.TryGetValue(bi, out double s)) score += s;
            }

            // Trừ điểm mỗi khi bắt gặp một tổ hợp vô lý
            for (int i = 0; i < text.Length - 1; i++)
            {
                string bi = text.Substring(i, 2);
                if (Array.IndexOf(illegalBigrams, bi) >= 0) score -= 10;
            }

            return score;
        }

        private string DecryptWithKey(string cipherText, string key)
        {
            char[] decrypted = new char[cipherText.Length];
            for (int i = 0; i < cipherText.Length; i++)
            {
                char c = cipherText[i];
                if (c >= 'A' && c <= 'Z')
                {
                    decrypted[i] = key[c - 'A'];
                }
                else if (c >= 'a' && c <= 'z')
                {
                    decrypted[i] = char.ToLower(key[c - 'a']);
                }
                else
                {
                    decrypted[i] = c;
                }
            }
            return new string(decrypted);
        }

        private async void btnDecrypt_Click(object sender, EventArgs e)
        {
            string original = rtbInput.Text.ToUpper();
            string cleanCipher = Regex.Replace(original, "[^A-Z]", "");
            if (string.IsNullOrEmpty(cleanCipher)) return;

            int restarts = (int)numericUpDown2.Value; // Số lần Restart (khuyến nghị: 10 - 20)
            if (restarts < 1) restarts = 1;

            int maxStagnation = (int)numericUpDown1.Value; // Số vòng lặp bế tắc tối đa

            btnDecrypt.Enabled = false;
            progressBar1.Maximum = restarts;
            progressBar1.Value = 0;

            await Task.Run(() =>
            {
                string globalBestKey = ALPHABET;
                double globalBestScore = double.MinValue;

                for (int r = 0; r < restarts; r++)
                {
                    // Random khởi tạo
                    char[] currentKeyArr = ALPHABET.ToCharArray().OrderBy(x => rand.Next()).ToArray();
                    string currentKey = new string(currentKeyArr);
                    double currentScore = CalculateFitness(FastDecrypt(cleanCipher, currentKey));

                    int stagnationCount = 0;

                    // Vòng lặp leo đồi (Hill-climbing) với cơ chế Stagnation
                    while (stagnationCount < maxStagnation)
                    {
                        char[] nextKeyArr = currentKey.ToCharArray();

                        // Tráo đổi ngẫu nhiên 2 ký tự trong key
                        int p1 = rand.Next(26);
                        int p2 = rand.Next(26);
                        (nextKeyArr[p1], nextKeyArr[p2]) = (nextKeyArr[p2], nextKeyArr[p1]);

                        string nextKey = new string(nextKeyArr);
                        double nextScore = CalculateFitness(FastDecrypt(cleanCipher, nextKey));

                        if (nextScore > currentScore)
                        {
                            currentScore = nextScore;
                            currentKey = nextKey;
                            stagnationCount = 0; // Reset bộ đếm khi tìm thấy kết quả tốt hơn
                        }
                        else
                        {
                            stagnationCount++; // Tăng bộ đếm nếu không có sự tiến bộ
                        }
                    }

                    // Cập nhật kết quả tốt nhất toàn cục
                    if (currentScore > globalBestScore)
                    {
                        globalBestScore = currentScore;
                        globalBestKey = currentKey;

                        this.Invoke((MethodInvoker)delegate {
                            rtbOutput.Text = FastDecryptWithFormat(original, globalBestKey);
                            txtCurrentKey.Text = globalBestKey;
                        });
                    }

                    this.Invoke((MethodInvoker)delegate {
                        if (progressBar1.Value < progressBar1.Maximum) progressBar1.Value++;
                    });
                }

                this.Invoke((MethodInvoker)delegate {
                    btnDecrypt.Enabled = true;
                    MessageBox.Show("Tìm kiếm hoàn tất!");
                });
            });
        }

        private string FastDecryptWithFormat(string cipher, string key)
        {
            char[] output = new char[cipher.Length];
            for (int i = 0; i < cipher.Length; i++)
            {
                char c = cipher[i];
                if (c >= 'A' && c <= 'Z')
                    output[i] = key[c - 'A'];
                else if (c >= 'a' && c <= 'z')
                    output[i] = char.ToLower(key[c - 'a']);
                else
                    output[i] = c; // Giữ nguyên khoảng trắng, dấu câu
            }
            return new string(output);
        }

        private void nudRestarts_ValueChanged(object sender, EventArgs e)
        {
            // Để trống hoặc thêm xử lý nếu cần
        }
    }
}