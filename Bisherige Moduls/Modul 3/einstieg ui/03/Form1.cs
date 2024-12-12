namespace _03
{
    public partial class Form1 : Form
    {
        private List<string> list0 = new List<string>();
        private List<string> list1 = new List<string>();
        private List<string> list2 = new List<string>();
        public Form1()
        {
            InitializeComponent();
            Listen();
            InderListeHinzufügen();
        }
        private void InderListeHinzufügen()
        {
            for (int i = 0; i < list0.Count; i++)
            {
                listBox1.Items.Add(list0[i]);
            }
        }
        private void Listen()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath1 = Path.Combine(desktop, "Produkte.txt");
            string[] files = File.ReadAllLines(filePath1);

            for (int i = 0; i < files.Length; i++)
            {
                string[] einzel = files[i].Split(';');
                for (int j = 0; j < einzel.Length; j += 3)
                {
                    list0.Add(einzel[j]);
                }

                for (int a = 1; a < einzel.Length; a += 3)
                {
                    list1.Add(einzel[a]);
                }

                for (int b = 2; b < einzel.Length; b += 3)
                {
                    list2.Add(einzel[b]);
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.SelectedIndex == i)
                {
                    textBox1.Text = list2[i];
                    textBox2.Text = list1[i];
                }
            }
        }
    }
}












int umlautCount = 0, aloneDerCount = 0, capitalStartCount = 0, froschCount = 0;
int dotEndCount = 0, szWordCount = 0, emptyLineCount = 0, threeLetterStartCount = 0;
int articleCount = 0;

for (int i = 0; i < lines.Length; i++)
{
    string line = lines[i];

    if (Regex.IsMatch(line, "[ÄÖÜäöü]")) umlautCount++;
    if (Regex.IsMatch(line, @"\bder\b")) aloneDerCount++;
    if (Regex.IsMatch(line, @"^[A-ZÄÖÜ]")) capitalStartCount++;
    if (Regex.IsMatch(line, @"\b(Frosch|Froschkönig)\b")) froschCount++;
    if (Regex.IsMatch(line, @"\.$")) dotEndCount++;
    if (Regex.IsMatch(line, @"\b\w*ß\b")) szWordCount++;
    if (Regex.IsMatch(line, @"^\s*$")) emptyLineCount++;
    if (Regex.IsMatch(line, @"^\b\w{3}\b")) threeLetterStartCount++;
    if (Regex.IsMatch(line, @"\b(der|die|das)\b")) articleCount++;
}

// Ausgabe der Anzahl der Treffer für jede Bedingung
Console.WriteLine($"Zeilen mit Umlauten: {umlautCount}");
Console.WriteLine($"Zeilen mit 'der' allein: {aloneDerCount}");
Console.WriteLine($"Zeilen, die mit einem großen Buchstaben beginnen: {capitalStartCount}");
Console.WriteLine($"Zeilen mit 'Frosch' oder 'Froschkönig': {froschCount}");
Console.WriteLine($"Zeilen mit Punkt am Ende: {dotEndCount}");
Console.WriteLine($"Zeilen mit einem Wort, das mit ß endet: {szWordCount}");
Console.WriteLine($"Anzahl der leeren Zeilen: {emptyLineCount}");
Console.WriteLine($"Zeilen mit einem 3-Buchstaben-Wort am Anfang: {threeLetterStartCount}");
Console.WriteLine($"Zeilen mit bestimmten Artikeln (der, die, das): {articleCount}");