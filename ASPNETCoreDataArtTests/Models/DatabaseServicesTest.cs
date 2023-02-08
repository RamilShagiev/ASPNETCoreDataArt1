using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPNETCoreDataArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCoreDataArt.Models.Tests
{
    [TestClass()]
    public class DatabaseServicesTest
    {
        [TestMethod()]
        public void formula_02_01_2023_equals_1()
        {
            var dh = new DatabaseServices();
            
            DateTime date = new DateTime(2023, 1, 2);
            int expected = 1;
            int actual = dh.Transform(date);
            Assert.AreEqual(expected, actual);
        }
    }
}