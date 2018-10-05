using System;

namespace DateTimeCustom
{
    public class DateCalculate
    {
        public DateTime Calculate5DayAhead(DateTime currentDate)
        {
            return currentDate.AddDays(5);
        }
        
    }
}
