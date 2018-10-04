using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeCustom
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Today { get; }
        DateTime DateTime { get; set; }
        DateTime AddDays(double i);
        DayOfWeek DayOfWeek { get; }
        int Day { get; }
        int CompareTo(IDateTime startTransferDate);
        string ToShortDateString();
    }
}
