namespace Aufgabe25

{

    internal class Program

    {

        private static void Main(string[] args)

        {

            Console.Write("Num1: ");

            string num1String = Console.ReadLine();

            Console.Write("Num2: ");

            string num2String = Console.ReadLine();

            int num1 = int.Parse(num1String);

            int num2 = int.Parse(num2String);

            bool numberAdded = false;

            int result = 0;

            Console.Write("Ergebnis: " + num1 + " * " + num2 + " = ");

            while (num1 >= 1)

            {

                if (num1 % 2 != 0)

                {

                    if (result != 0)

                    {

                        Console.Write(num2);

                        numberAdded = true;

                    }

                    result = result + num2;

                    //numberAdded = true;

                }

                num1 = num1 / 2;

                num2 = num2 * 2;

                if (num1 >= 1 && numberAdded == true)

                {

                    numberAdded = false;

                    Console.Write(" + ");

                }

            }

            Console.WriteLine(" = " + result);

        }

    }

}
