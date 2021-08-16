using Hyvinvointisovellus.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace Hyvinvointisovellus.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OmattiedotTyontekijaTesti()
        {
            var controller = new HomeController();
            ViewResult result = controller.OmattiedotTyontekija() as ViewResult;
            Assert.AreEqual("IndexTyontekija", result.ViewName);
        }

        [TestMethod]
        public void OmattiedotTyonantajaTesti()
        {
            var controller = new HomeController();
            var result = controller.OmattiedotTyonantaja() as ViewResult;
            Assert.AreEqual("IndexTyonantaja", result.ViewName);
        }

        [TestMethod]
        public void IndexTyontekijaTesti()
        {
            var controller = new HomeController();
            var result = controller.IndexTyontekija() as ViewResult;
            Assert.AreEqual("IndexTyontekija", result.ViewName);
        }

        [TestMethod]
        public void IndexTyonantajaTesti()
        {
            var controller = new HomeController();
            var result = controller.IndexTyontekija() as ViewResult;
            Assert.AreEqual("IndexTyonantaja", result.ViewName);
        }
    }
}
