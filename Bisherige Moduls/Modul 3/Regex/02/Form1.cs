using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
             string Anwendername= textBox1.Text;
            string Email = textBox2.Text;
            string telefon = textBox3.Text;
            string ip = textBox4.Text;

            if (Regex.IsMatch(Anwendername, "[@#!$&]")|| Anwendername==string.Empty)
            {
                MessageBox.Show("Anwendername üngultig");
            }
            else
            {
                MessageBox.Show("Anwendename ok");
            }
            if (Regex.IsMatch(Email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {
                MessageBox.Show("Email gultig");
            }
            else
            {
                MessageBox.Show("Email nicht in ordnung");
            }
            if (Regex.IsMatch(telefon,@"^\+\d{1,2} \d{3,4} \d{4,8}$"))
            {
                MessageBox.Show("valide telefon");
            }
            else
            {
                MessageBox.Show("unvalid telefon");
            }
            if (Regex.IsMatch(ip, @"(([0-2]?[0-5]{1}[0-5]{1})\.){4}"))
            {
                MessageBox.Show("in ordnung");
            }
            else
            {
                MessageBox.Show("nicht");
            }
        }
    }
}

//Die E-Mail muss mindestens das Zeichen @ enthalten. Es dürfen außer dem Zeichen @ in 
//einer Adresse nur Buchstaben, Ziffern und der Punkt (.) und Bindestrich (-) verwendet 
//werden.

// ^[a-zA-Z0-9.-]+@[a-zA-Z0-9.-]+$
