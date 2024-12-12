namespace _04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            vector3 vector1;
            vector1.x = 1;
            vector1.y = 2;
            vector1.z = 3;


            vector3 vector2;
            vector2.x = 4;
            vector2.y = 5;
            vector2.z = 6;

            vector3 resaultVector =vector1.Multiply(vector2);
            Console.WriteLine(resaultVector.AsString());

        }
    }
}
