using System;
using System.Collections.Generic;
using System.Text;

namespace T05DateModifier
{
    public class DateModifier
    {

        public static int DaysDifference(string startDateString, string EndDateString)
        {
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(EndDateString);
            TimeSpan daysDifference = endDate - startDate;
            
            return Math.Abs(daysDifference.Days);
        }
    }
}
