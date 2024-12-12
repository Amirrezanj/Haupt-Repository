namespace Aufgabe_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("hi pl write 3 Nummbers");

            Console.WriteLine("First Number:");
            string Num1Text = Console.ReadLine();
            int Num1 = 0;
            bool Num1Valid = int.TryParse(Num1Text, out Num1);

            Console.WriteLine("now second number");
            string Num2Text = Console.ReadLine();
            int Num2 = 0;
            bool Num2Valid = int.TryParse(Num2Text, out Num2);

            Console.WriteLine("now last one");
            string Num3text = Console.ReadLine();
            int Num3 = 0;
            bool Num3Valid = int.TryParse(Num3text, out Num3);

            if (Num1Valid && Num2Valid && Num3Valid)
            {
                if (Num1 > Num2 && Num1 > Num3)
                {
                    Console.WriteLine("The Biggest Number is " + Num1);
                }
                else if (Num2 > Num1 && Num2 > Num3)
                {
                    Console.WriteLine("the biggest Number is " + Num2);
                }
                else
                {
                    Console.WriteLine("The biggest number is " + Num3);
                }
            }
            else
            {
                Console.WriteLine("Falsche eingabe");
            }
        }
    }
}

//namespace Aufgabe4
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            Console.WriteLine("Gib die erste Zahl ein");
//            string numberOneText = Console.ReadLine();
//            bool numberOneValid = int.TryParse(numberOneText, out int numberOne);

//            if (numberOneValid)
//            {
//                Console.WriteLine("Gib die zweite Zahl ein");
//                string numberTwoText = Console.ReadLine();
//                bool numberTwoValid = int.TryParse(numberTwoText, out int numberTwo);

//                if (numberTwoValid)
//                {
//                    Console.WriteLine("Gib die dritte Zahl ein");
//                    string numberThreeText = Console.ReadLine();
//                    bool numberThreeValid = int.TryParse(numberThreeText, out int numberThree);

//                    if (numberThreeValid)
//                    {
//                        if (numberOne > numberTwo && numberOne > numberThree)
//                        {
//                            Console.WriteLine("Die Zahl " + numberOne + " ist die größte");
//                        }
//                        else if (numberTwo > numberOne && numberTwo > numberThree)
//                        {
//                            Console.WriteLine("Die Zahl " + numberTwo + " ist die größte");
//                        }
//                        else
//                        {
//                            Console.WriteLine("Die Zahl " + numberThree + " ist die größte");
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine("Ungültige dritte Zahl");
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("Ungültige zweite Zahl");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Ungültige erste Zahl");
//            }
//        }
//    }
//}