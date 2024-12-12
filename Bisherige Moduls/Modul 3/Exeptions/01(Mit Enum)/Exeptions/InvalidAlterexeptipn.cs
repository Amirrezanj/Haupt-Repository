using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Mit_Enum_.Models;

namespace _01_Mit_Enum_.Exeptions
{
    internal class InvalidAlterexeptipn : Exception
    {
        public enum Erorcode
        {
            NegativeAlter,
            alt123
        }

        public Erorcode erorcode { get; set; }

        public InvalidAlterexeptipn(Erorcode Code, string msg) : base(msg)
        {
            erorcode = Code;
        }
    }
}