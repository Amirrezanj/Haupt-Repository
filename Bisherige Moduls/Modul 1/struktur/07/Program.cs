namespace _07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] monatEnde = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Date[] Kalender= new Date[365];

            int zähler= 0;

            for (int i = 1 ; i <= 12 ; i++ )
            {
                for (int j = 1 ; j <= monatEnde[i-1]; j++)
                {
                    Kalender[zähler].Day= j;
                    Kalender[zähler].Month = i;
                    Kalender[zähler].Year = 2011;
                    zähler++;
                }
                
            }
            foreach (Date date in Kalender)
            {
                Console.WriteLine($"tag {date.Day} monat{date.Month} Year {date.Year}");
            }

        }
    }
}