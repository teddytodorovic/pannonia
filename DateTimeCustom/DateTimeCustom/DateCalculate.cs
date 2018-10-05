using System;

namespace DateTimeCustom
{
    public class DateCalculate
    {

        private IDateTime currentdate;

        public IDateTime Currentdate { get => currentdate; set => currentdate = value; }

        public DateTime Calculate5DayAhead()
        {
            return currentdate.Today.AddDays(5);
        }
        
    }
}
