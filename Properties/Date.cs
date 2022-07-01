using System;

namespace ConsoleApplication1.Properties
{
    public struct Date
    {

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;

            if (day < 0 || month < 0 || day > 31 || month > 12)
            {
                throw new Exception();
            }

            this._nameOfMonth = (NameOfMonth)month;
        }

        public int getDay()
        {
            return this.day;
        }

        public int getMonth()
        {
            return this.month;
        }

        public int getYear()
        {
            return this.year;
        }

        public String getDate()
        {
            if (month < 10)
            {
                if (day < 10)
                {
                    return "date = [0" + this.day.ToString() + ".0" + this.month.ToString() + "." +
                           this.year.ToString() + "]";
                }
                else
                {
                    return "date = [" + this.day.ToString() + ".0" + this.month.ToString() + "." +
                           this.year.ToString() + "]";
                }
            }
            else
            {
                if (day < 10)
                {
                    return "date = [0" + this.day.ToString() + "." + this.month.ToString() + "." +
                           this.year.ToString() + "]";
                }
                else
                {
                    return "date = [" + this.day.ToString() + "." + this.month.ToString() + "." +
                           this.year.ToString() + "]";
                }
            }
        }
        
        private int day;
        private int month;
        private int year;

        private NameOfMonth _nameOfMonth;
    }

    public enum NameOfMonth
    {
        January = 1, February = 2, March = 3,
        April = 4, May = 5, June = 6,
        July = 7, August = 8, September = 9,
        October = 10, November = 11, December = 12
    }
}