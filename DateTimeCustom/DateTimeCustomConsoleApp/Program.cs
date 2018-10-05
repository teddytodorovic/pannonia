using System;
using DateTimeCustom;
using Ninject;

namespace DateTimeCustomConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Bind<IDateTime>().To<DateTimeAlive>();

            Console.WriteLine("Welcome to the Date Calculator");
            DateCalculate dateCalculate = new DateCalculate();
            dateCalculate.Currentdate = kernel.Get<IDateTime>();
            
            DateTime calculatedDate = dateCalculate.Calculate5DayAhead();
            Console.WriteLine("Current Date: {0} - Calculated Date: {1}", kernel.Get<IDateTime>().Today, calculatedDate );
            Console.ReadLine();
        }
    }
}
