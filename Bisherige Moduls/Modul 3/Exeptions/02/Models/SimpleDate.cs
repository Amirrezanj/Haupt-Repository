using _02.Exceptions;
using _02.Models;


namespace _02.Models
{
    internal class SimpleDate
    {
       
        public bool IsSchaljahr(int zahl)
        {
            if (zahl >=1582)
            {
                bool schlat = (zahl % 4 == 0 && zahl % 100 != 0) || (zahl % 400 == 0);
                return schlat;
            }
            else
            {
                return zahl % 4 == 0;
            }
        }
        private bool IsValidDay(int year,int mounth,int day)
        {

        }

        



        public int Year
        {
            get => Year;
            set
            {
                if (value <= 1 && value >= 9999)
                {
                    throw new InvalidYearException("YearOutOfRange");
                }
                Year = value;
            }
        }
        public int Month
        {
            get => Month;
            set
            {
                if (value <= 1 && value >= 12)
                {
                    throw new InvalidMonthException("MonthOutOfRange");
                }
                Month = value;
            }
        }
        public int Day
        {
            get => Day;
            set
            {
                if(value)
            }
        }

    }
}



















using System;

namespace _02.Models
{
    internal class SimpleDate
    {
        private int year;
        private int month;
        private int day;

        public int Year
        {
            get => year;
            set
            {
                if (value < 1 || value > 9999)
                {
                    throw new YearOutOfRangeException("Year must be between 1 and 9999.");
                }
                year = value;
            }
        }

        public int Month
        {
            get => month;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new MonthOutOfRangeException("Month must be between 1 and 12.");
                }
                month = value;
            }
        }

        public int Day
        {
            get => day;
            set
            {
                if (!IsValidDay(value, Month, Year))
                {
                    throw new DayOfMonthException("Invalid day for the given month and year.");
                }
                day = value;
            }
        }

        private bool IsValidDay(int day, int month, int year)
        {
            if (day < 1) return false;

            if (IsLeapYear(year) && month == (int)Months.February)
            {
                return day <= 29;
            }

            return day <= DaysInMonth((Months)month);
        }

        private int DaysInMonth(Months month)
        {
            switch (month)
            {
                case Months.January:
                case Months.March:
                case Months.May:
                case Months.July:
                case Months.August:
                case Months.October:
                case Months.December:
                    return 31;
                case Months.April:
                case Months.June:
                case Months.September:
                case Months.November:
                    return 30;
                case Months.February:
                    return 28;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool IsLeapYear(int year)
        {
            if (year >= 1582)
            {
                return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            }
            else
            {
                return year % 4 == 0;
            }
        }
    }

    enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}

namespace _02.Exceptions
{
    public class YearOutOfRangeException : Exception
    {
        public YearOutOfRangeException(string message) : base(message) { }
    }

    public class MonthOutOfRangeException : Exception
    {
        public MonthOutOfRangeException(string message) : base(message) { }
    }

    public class DayOfMonthException : Exception
    {
        public DayOfMonthException(string message) : base(message) { }
    }
}
