using System;
using DateTimeCustom;

namespace DateTimeCustomConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Date Calculator");
            DateCalculate dateCalculate = new DateCalculate();
            DateTimeAlive dateTimeAlive = new DateTimeAlive();
            DateTime calculatedDate = dateCalculate.Calculate5DayAhead(dateTimeAlive.Today);
            Console.WriteLine("Current Date: {0} - Calculated Date: {1}", dateTimeAlive.Today, calculatedDate );
            Console.ReadLine();
        }
    }
}
