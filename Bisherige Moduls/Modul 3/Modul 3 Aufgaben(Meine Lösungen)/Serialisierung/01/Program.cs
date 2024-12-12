using System.Xml.Serialization;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("amir", "harzstrasse", "heiligenhaus", 20);
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using TextWriter writer = new StreamWriter(@"C:\Users\ITAD2-TN15\Desktop\persoon.xml");
            serializer.Serialize(writer, person);

            //XmlSerializer deserializer = new XmlSerializer(typeof(Person));
            //using TextReader reader = new StreamReader(@"C:\Users\ITAD2-TN15\Desktop\person.xml");
            //Person? person1 = (Person?)deserializer.Deserialize(reader);
            //if (person1 != null)
            //{
            //    Console.WriteLine(person1.Name+person1.Address);
            //}


        }
    }
    public class Person
    {
        //[XmlAttribute]
        public string Name { get; set; }
        //[XmlAttribute]
        public string Address { get; set; }
        //[XmlIgnore]
        public string City { get; set; }
        //[XmlText]
        public int Id { get; set; }

        //wegen XML Nicht löschen !!!!!!!!!
        public Person() { }
        public Person(string name , string address , string city , int id)
        {
            Name = name;
            Address = address;
            City = city;
            Id = id;
        }
    }
}
