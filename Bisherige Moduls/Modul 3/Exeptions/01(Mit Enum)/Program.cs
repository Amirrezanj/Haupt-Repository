using _01_Mit_Enum_.Exeptions;
using _01_Mit_Enum_.Models;
using 

namespace _01_Mit_Enum_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            try
            {
                person.Alter = 123;
            }
            catch (InvalidAlterexeptipn ex) when (ex.erorcode == InvalidAlterexeptipn.Erorcode.alt123)
            {
                Console.WriteLine("123 jahre alt????");
            }
            catch(InvalidAlterexeptipn ex) when (ex.erorcode==InvalidAlterexeptipn.Erorcode.NegativeAlter)
            {
                Console.WriteLine("negative zahl?????");
            }
            
        }
            
    }
}
