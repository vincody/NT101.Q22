using ClassicalCryptographyApp.Forms;
namespace ClassicalCryptographyApp
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void buttonCaesar_Click(object sender, EventArgs e)
        {
            Caesar_cipher frmCaesar = new Caesar_cipher();
            frmCaesar.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MonoCipher frmMono = new MonoCipher();
            frmMono.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayFair playFair = new PlayFair();
            playFair.Show();
        }

        private void buttonVigenere_Click(object sender, EventArgs e)
        {
            VigenereED vigenereED = new VigenereED();
            vigenereED.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ByteAddition byteAddition = new ByteAddition();
            byteAddition.Show();
        }
    }
}
