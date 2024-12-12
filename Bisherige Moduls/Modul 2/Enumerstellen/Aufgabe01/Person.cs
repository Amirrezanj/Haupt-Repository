namespace Aufgabe01
{
    internal class Person
    {
        private string _firstName;
        private string _lastName;
        private Gender  _gender;
        private DateTime _birthday;

        public Person(string firstname,string lastname, Gender gender,DateTime birthday)
        {
            _firstName=firstname;
            _lastName=lastname;
            _gender=gender;
            _birthday=birthday;
        }
        public void SetFirstName(string firstname)
        {
            _firstName = firstname;
           
        }
        public string GetFirstName()
        {
            return _firstName;
        }

        public void SetLastName(string lastname)
        {
            _lastName = lastname;
        }
        public string GetLastName()
        {
            return _lastName;
        }
        public void SetGender(Gender gender)
        {
            _gender =gender;
        }
        public Gender GetGender()
        {
            
            return _gender;
        }
        public DateTime GetBirthDate(DateTime birthday)
        {
            _birthday = birthday;
            return birthday;
        }
        public string GetFullName()
        {
            return $"{_firstName},{_lastName}";
        }
    }
}
