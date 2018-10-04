using DateTimeCustom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;

namespace DateTimeCustomTests
{
    [TestClass]
    public class DateCalculateTests
    {
        [TestInitialize]
        public void Setup()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IDateTime>().To<DateTimeAlive>();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
