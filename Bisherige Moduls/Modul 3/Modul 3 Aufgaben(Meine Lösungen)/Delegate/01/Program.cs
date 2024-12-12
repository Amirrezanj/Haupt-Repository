using System.Threading.Channels;

namespace _01
{
    internal delegate void CharacterHandler(string msg);

    internal class Program
    {
        private static void Main(string[] args)
        {
            Charechter charechter = new Charechter();
            CharacterHandler Upperhandler = charechter.UpperCase;
            CharacterHandler Lowerhandler = charechter.LowerCase;
            CharacterHandler UpperLower = charechter.UpperLower;

            Lowerhandler("AMIR");
            Upperhandler("amir");
            UpperLower("Amir");

            CharacterHandler Alleshandler = charechter.LowerCase;
            Alleshandler += charechter.UpperCase;
            Alleshandler += charechter.UpperLower;

            Alleshandler("Amir");

            CharacterHandler anonymousHandler = delegate (string msg)
            {
                Console.WriteLine($"test messege : {msg}");
            };
            anonymousHandler("Anonyme Amir");
        }
    }

    public class Charechter
    {
        public void UpperCase(string text)
        {
            text = text.ToUpper();
            Console.WriteLine(text);
        }

        public void LowerCase(string text)
        {
            text = text.ToLower();
            Console.WriteLine(text);
        }

        public void UpperLower(string text)
        {
            Console.WriteLine(text);
        }
    }
}