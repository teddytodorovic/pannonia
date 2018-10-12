using System;
using System.Reflection;

namespace PartialClassExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin...");
            Brain brain = new Brain();

            PropertyInfo[] properties = typeof(Brain).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name); 
            }

            Console.ReadLine();
        }
    }
}
