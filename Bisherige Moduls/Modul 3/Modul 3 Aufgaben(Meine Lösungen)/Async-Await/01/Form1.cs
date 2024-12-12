namespace _01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Text = "wird berechnet";


           

        }

        
        private double ComputePi()
        {
            double sum = 0.0;
            const double step = 1e-9;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                double x = (i + 0.5) * step;
                sum += 4.0 / (1.0 + x * x);
            }
            return sum * step;
        }
    }
}



