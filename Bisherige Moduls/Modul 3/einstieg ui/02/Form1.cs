using static System.Net.Mime.MediaTypeNames;

namespace _02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Pali(textBox1.Text))
            {
                label2.Text = "is palindrom";
            }
            else
            {
                label2.Text = "isnt palindrom";
            }
        }
        private bool Pali(string text)
        {
            bool isPalindrome = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != text[text.Length-1-i])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }
    }
}

