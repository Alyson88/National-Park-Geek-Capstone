using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        IParkDAO parkDAO;
        ISurveyDAO surveyDAO;

        [TestMethod]
        public void HomeController_IndexAction_ReturnIndexView()
        {
            //Arrange
            HomeController controller = new HomeController(parkDAO, surveyDAO);

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}