using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeCustom
{
    public class DateTimeStatic : IDateTime
    {
        private DateTime dateTime;
        private DateTime staticClockToReturnForToday;

        public DateTimeStatic()
        { }

        public DateTimeStatic(DateTime StaticClockToReturnToday)
        {
            this.staticClockToReturnForToday = StaticClockToReturnToday;
        }

        public DateTime DateTime
        {
            get
            { return dateTime; }
            set
            { dateTime = value; }
        }

        public DateTime Now { get { return staticClockToReturnForToday; } }
        public DateTime Today { get { return staticClockToReturnForToday; } }

        public DateTime AddDays(double i)
        {
            return dateTime.AddDays(i);
        }

        public DayOfWeek DayOfWeek { get { return dateTime.DayOfWeek; } }




        public int CompareTo(IDateTime startTransferDate)
        {
            return dateTime.CompareTo(startTransferDate.DateTime);
        }

        public int Day { get { return dateTime.Day; } }

        public string ToShortDateString()
        { return DateTime.ToShortDateString(); }

    }
}
