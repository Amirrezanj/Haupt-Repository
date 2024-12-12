using _02.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Exceptions
{
    
    public class InvalidYearException : Exception
    {
        
        public InvalidYearException(string msg):base(msg) 
        {
        }
    }
    public class InvalidMonthException : Exception
    {
       


        public InvalidMonthException(string msg) : base(msg)
        {
            
        }
    }
    public class InvalidDayException : Exception
    {
        public enum Monatstage
        {
            januar = 31,
            februar = 28,
            märz = 31,
            april = 30,
            mai = 31,
            juni = 30,
            juli = 31,
            august = 31,
            september = 30,
            oktober = 31,
            november = 30,
            dezember = 31
        }
        
        public Monatstage monatstage { get; set; }
             
        public InvalidDayException(string msg,Monatstage tage):base(msg) 
        {
            monatstage = tage;
        }
    }
}





















//using System;

//namespace _02.Models
//{
//    internal class SimpleDate
//    {
//        private int year;
//        private int month;
//        private int day;

//        public int Year
//        {
//            get => year;
//            set
//            {
//                if (value < 1 || value > 9999)
//                {
//                    throw new YearOutOfRangeException("Year must be between 1 and 9999.");
//                }
//                year = value;
//            }
//        }

//        public int Month
//        {
//            get => month;
//            set
//            {
//                if (value < 1 || value > 12)
//                {
//                    throw new MonthOutOfRangeException("Month must be between 1 and 12.");
//                }
//                month = value;
//            }
//        }

//        public int Day
//        {
//            get => day;
//            set
//            {
//                if (!IsValidDay(value, Month, Year))
//                {
//                    throw new DayOfMonthException("Invalid day for the given month and year.");
//                }
//                day = value;
//            }
//        }

//        private bool IsValidDay(int day, int month, int year)
//        {
//            if (day < 1) return false;

//            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

//            if (IsLeapYear(year) && month == 2)
//            {
//                return day <= 29;
//            }

//            return day <= daysInMonth[month - 1];
//        }

//        private bool IsLeapYear(int year)
//        {
//            if (year >= 1582)
//            {
//                return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
//            }
//            else
//            {
//                return year % 4 == 0;
//            }
//        }
//    }
//}

//namespace _02.Exceptions
//{
//    public class YearOutOfRangeException : Exception
//    {
//        public YearOutOfRangeException(string message) : base(message) { }
//    }

//    public class MonthOutOfRangeException : Exception
//    {
//        public MonthOutOfRangeException(string message) : base(message) { }
//    }

//    public class DayOfMonthException : Exception
//    {
//        public DayOfMonthException(string message) : base(message) { }
//    }
//}
