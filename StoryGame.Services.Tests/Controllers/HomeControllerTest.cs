using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoryGame.Services;
using StoryGame.Services.Controllers;

namespace StoryGame.Services.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
