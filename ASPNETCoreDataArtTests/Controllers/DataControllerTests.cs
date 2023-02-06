using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPNETCoreDataArt.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ASPNETCoreDataArt.Controllers.Tests
{
    [TestClass()]
    public class DataControllerTests
    {

        public readonly IConfiguration _configuration;

        public DataControllerTests(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [TestMethod()]
        public void GetData_ID1_return_First()
        {
            int ID = 1;
            string expected = "First";

            var controller = new DataController(_configuration);

            string actual = controller.GetData(ID);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Transform_2023_1_2_return_1()
        {
            DateTime dateTime = new DateTime(2023, 1, 2);
            int expected = 1;

            var controller = new DataController(_configuration);

            int actual = controller.Transform(dateTime);

            Assert.AreEqual(expected, actual);
        }
    }
}