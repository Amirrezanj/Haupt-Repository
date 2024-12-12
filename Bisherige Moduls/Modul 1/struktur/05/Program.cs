namespace _05
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

            vector3 resault = vector1.Sum(vector2);
            Console.WriteLine(resault.AsString());

            vector3 reault2 = vector1.Subtraktion(vector2);
            Console.WriteLine(reault2.AsString());
        }
    }
}
