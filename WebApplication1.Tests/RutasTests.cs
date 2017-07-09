using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Routing;
using WebApp;

namespace WebApplication1.Tests
{
    [TestClass]
    public class RutasTests
    {
        [TestMethod]
        public void RutaRootRetornaIndexHome()
        {
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(h => h.Request.AppRelativeCurrentExecutionFilePath)
                .Returns("~/");

            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);

            var routeData = routeCollection.GetRouteData(mockHttpContext.Object);

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
        }
    }
}
