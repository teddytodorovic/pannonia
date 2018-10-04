using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeCustom
{
    public class DateTimeAlive : IDateTime
    {
        private DateTime dateTime;

        public DateTime DateTime
        {
            get
            { return dateTime; }
            set
            { dateTime = value; }
        }

        public DateTime Now { get { return DateTime.Now; } }
        public DateTime Today { get { return DateTime.Today; } }

        public DateTime AddDays(double i)
        {
            return dateTime.AddDays(i);
        }

        public int CompareTo(IDateTime startTransferDate)
        {
            return dateTime.CompareTo(startTransferDate.DateTime);
        }

        public DayOfWeek DayOfWeek { get { return dateTime.DayOfWeek; } }

        public int Day { get { return dateTime.Day; } }

        public string ToShortDateString()
        { return DateTime.ToShortDateString(); }

    }
}

