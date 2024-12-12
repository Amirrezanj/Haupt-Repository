namespace _02
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Address address = new Address();
            Person amir = new Person(address);
            Animal hund = new Animal(amir);
            amir.SetAnimal(hund);
        }
    }

    // Person -> Address (Unidirectional)
    // Person 1 - 0-1 Animal (Bidirectional)
    public class Person
    {
        private Address _address;
        private Animal _animal; // 0-1

        public Person(Address address)
        {
            this._address = address;
        }

        public void SetAnimal(Animal animal)
        {
            this._animal = animal;
        }
    }

    public class Address
    { }

    public class Animal
    {
        private Person _owner;

        public Animal(Person owner)
        {
            this._owner = owner;
        }
    }
}