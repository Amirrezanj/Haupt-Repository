using Newtonsoft.Json;
namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderpath=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath = Path.Combine(folderpath, "11. car.json");
            string json = File.ReadAllText(filepath);
            Auto? auto = JsonConvert.DeserializeObject<Auto>(json);
            Console.WriteLine(json);



        }
    }
    public class Auto
    {
        public string name {  get; set; }
        public string model {  get; set; }
        public int year {  get; set; }
        public Engine engine { get; set; }
        public List<Passenger> passengers { get; set; }
    }
    public class Engine
    {
        public string name {  get; set; }
        public int power {  get; set; }
        public int torgue {  get; set; }
    }
    
    public class Passenger
    {
        public string name { get; set; }
        public int age {  get; set; }
        public Address address { get; set; }
        public List<Hobbie> hobbies { get; set; }

    }
    public class Address
    {
        public string street {  get; set; }
        public string city { get; set; }
        public int zipcode { get; set; }
    }
    public class Hobbie
    {
        public string name { get; set; }
        public string Description {  get; set; }
    }
}
