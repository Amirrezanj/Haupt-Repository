namespace _01.Models
{
    public class Student
    {
        private string _name=string.Empty;

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (value.Length>2 && value.Length<20 && !string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
            }
        }

        private int _alter;

        public int Alter
        {
            get
            {
                return _alter;
            }
            set
            {
                if (value > 1 && value < 99)
                {
                    _alter = value;
                }
            }
        }

        private int _Note;

        public int Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }

        //public string Name { get; private set; }
        //public int Alter { get; set; }
        //public int Note { get; set; }

        public override string ToString()
        {
            return $"Student: {Name} , {Alter} ,{Note}";
        }

        public Student(string name, int alter)
        {
            Name = name;
            Alter = alter;
        }
    }
}