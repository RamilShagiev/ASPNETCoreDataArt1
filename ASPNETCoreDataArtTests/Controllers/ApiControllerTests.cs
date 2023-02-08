using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASPNETCoreDataArt.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using ASPNETCoreDataArt.Models;
using System.Security.Cryptography.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace ASPNETCoreDataArt.Controllers.Tests
{
    [TestClass()]
    public class ApiControllerTests
    {

        [TestMethod()]
        public void GetText_01_02_2023_equals_First()
        {
            //Arrange
            var mock = new Mock<ILogger<ApiController>>();
            ILogger<ApiController> logger = mock.Object;

            var databaseServicesMoq = new DatabaseServices();

            var databaseHandlerMoq = new Mock<DatabaseHandler>();
            databaseHandlerMoq.Setup(a => a.GetTextById(It.IsAny<int>())).Returns("First");
            //TestClass t = databaseHandlerMoq.Object;

            string expected = "First";

            //Act
            DateTime date = new DateTime(2023, 1, 2);
            var apiController = new ApiController(logger, databaseServicesMoq, databaseHandlerMoq.Object);
            string actual = apiController.GetText(date);


            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
