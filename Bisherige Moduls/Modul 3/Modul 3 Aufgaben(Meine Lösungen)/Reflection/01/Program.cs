using System.Reflection;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type sttype = typeof(string);

            var statischemembers = sttype.GetMembers(BindingFlags.Public | BindingFlags.Static);
            foreach (var member in statischemembers)
            {
                Console.WriteLine(member.Name+" "+member.MemberType);
            }
            Console.WriteLine("----------------");

            var methods = sttype.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine("------------");

            var fields=sttype.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            
            foreach (var field in fields)
            {
                Console.WriteLine(field);
            }

        }
    }
}
