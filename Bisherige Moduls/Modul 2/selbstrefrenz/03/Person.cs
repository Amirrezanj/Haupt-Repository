namespace Aufgabe03
{
    public class Person
    {
        private string _name;
        private DateTime _birthdate;

        public Person(string name, string birthdate) : this(name, DateTime.Parse(birthdate))
        {
        }

        public Person(string name, DateTime birthdate)
        {
            _name = name;
            _birthdate = birthdate;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetAlter()
        {
            int years = DateTime.Now.Date.Year - _birthdate.Year;

            DateTime birthdateCopy = _birthdate.AddYears(years);

            if (birthdateCopy > DateTime.Now.Date)
            {
                return years - 1;
            }

            return years;
        }

        //public int GetAlter()
        //{
        //    int years = DateTime.Now.Year - _birthdate.Year;

        //    if (_birthdate.DayOfYear > DateTime.Now.DayOfYear)
        //    {
        //        return years - 1;
        //    }

        //    return years;
        //}
    }
}