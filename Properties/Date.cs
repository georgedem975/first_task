using System;

namespace ConsoleApplication1.Properties
{
    public static class Date
    {
        public static string GetDate(this DateTime dateTime)
        {
            if (dateTime.Month < 10)
            {
                if (dateTime.Day < 10)
                {
                    return $"date = [0{ dateTime.Day.ToString() }.0{ dateTime.Month.ToString() }.{dateTime.Year.ToString()}]";
                    
                }
                return $"date = [{ dateTime.Day.ToString() }.0{ dateTime.Month.ToString() }.{ dateTime.Year.ToString() }]";
            }
            if (dateTime.Day < 10)
            {
                return $"date = [0{ dateTime.Day.ToString() }.{ dateTime.Month.ToString() }.{dateTime.Year.ToString()}]";
            }
            return $"date = [{ dateTime.Day.ToString() }.{ dateTime.Month.ToString() }.{dateTime.Year.ToString()}]";
        }
    }
}