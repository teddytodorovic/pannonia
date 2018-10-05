using DateTimeCustom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using System;

namespace DateTimeCustomTests
{
    [TestClass]
    public class DateCalculateTests
    {

        StandardKernel kernel = new StandardKernel();


        [TestInitialize]
        public void Setup()
        {
            DateTime staticDateTime = new DateTime(2018, 10, 1);
            kernel.Bind<IDateTime>().To<DateTimeStatic>().WithConstructorArgument(staticDateTime);
            
        }

        [TestMethod]
        public void Easy()
        {
            DateCalculate dateCalculate = new DateCalculate();
            dateCalculate.Currentdate = kernel.Get<IDateTime>();

            DateTime result = dateCalculate.Calculate5DayAhead();
            Assert.AreEqual(result, new DateTime(2018, 10, 7));
        }

        [TestMethod]
        public void Easytoo()
        {
            DateCalculate dateCalculate = new DateCalculate();
            dateCalculate.Currentdate = kernel.Get<IDateTime>();

            DateTime result = dateCalculate.Calculate5DayAhead();
            Assert.AreEqual(result, new DateTime(2018, 10, 6));
        }
    }
}
