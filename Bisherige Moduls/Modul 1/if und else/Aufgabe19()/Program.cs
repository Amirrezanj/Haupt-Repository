namespace Aufgabe19__
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hi schreib mal dein gewicht in kg");
            string gewichttext = Console.ReadLine();
            bool gewichtvalid = double.TryParse(gewichttext, out double gewicht);

            if (gewichtvalid)
            {
                Console.WriteLine("und jetzt bitte deine Grösse in m");
                string groessetext = Console.ReadLine();
                bool grooesevalid = double.TryParse(groessetext, out double groesse);

                double bmi = gewicht / (groesse * groesse);
                Console.WriteLine("your bmi is " + bmi);

                if (bmi < 18.5)
                {
                    Console.WriteLine("untergewicht");
                }
                else if (bmi > 18.5 && bmi < 24.9)
                {
                    Console.WriteLine("NormalGewicht");
                }
                else if (bmi > 25 && bmi < 29.9)
                {
                    Console.WriteLine("Übergewicht");
                }
                else (bmi>29.9)
                {
                    Console.WriteLine("Zu Fett!!!!!");
                }
                
            }
            else
            {
                Console.WriteLine("falsche eingabe");
            }
        }
    }
}

// BMI= (Gewicht in kg)/ (Körpergroße in m)².