using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Mit_Enum_.Exeptions;

namespace _01_Mit_Enum_.Models
{
    internal class Person
    {
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public int Alter
        {
            get =>  Alter;
            set
            {
                if (value < 0)
                {
                    throw new InvalidAlterexeptipn(InvalidAlterexeptipn.Erorcode.NegativeAlter,"negative alter???");
                }
                if (value ==123)
                {
                    throw new InvalidAlterexeptipn(InvalidAlterexeptipn.Erorcode.alt123, "123 jahre alt");
                }
            }
        }
    }
}
