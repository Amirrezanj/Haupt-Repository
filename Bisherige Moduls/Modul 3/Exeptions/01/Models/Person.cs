using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.Exeptions;
using Faker;

namespace _01.Models
{
    internal class Person
    {
        public string VorName { get; set; }
        public string Nachname { get; set; }
        public int Alter
        {
            get => Alter;
            set
            {
                if (value < 0)
                {
                    throw new InvalidAlterExeption("kannst du nicht minus eingeben ");
                }
                if (value > 100)
                {
                    throw new InvalidAlterExeption("Über 100 geht nicht");
                }
            }
        }
    }
}