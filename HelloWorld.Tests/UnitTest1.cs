using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Routes_PageHomeIndex2_RetourneControleurHomeEtMethodeIndexEtParam2()
        {

            var routeData = DefinirUrl("~/Home/Index/2");

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual("2", routeData.Values["id"]);
        }

        [TestMethod]
        public void Routes_PageHome_RetourneControleurHomeEtMethodeIndex()
        {

            var routeData = DefinirUrl("~/");

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Home", routeData.Values["controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
        }


        [TestMethod]
        public void Routes_UrlBidon_RetourneNull()
        {

            var routeData = DefinirUrl("~/Url/bidon/pas/bonne");

            Assert.IsNull(routeData);
        }





        [TestMethod]
        public void Routes_MeteoAujourdhui_RetourneControleurMeteoMethodeAfficherParamAujourdhui()
        {
            var today = DateTime.Now;
            var routeData = DefinirUrl($"~/{today.Day}/{today.Month}/{today.Year}");

            Assert.IsNotNull(routeData);
            Assert.AreEqual("Meteo", routeData.Values["controller"]);
            Assert.AreEqual("Afficher", routeData.Values["action"]);
            Assert.AreEqual(today.Day.ToString(), routeData.Values["jour"]);
            Assert.AreEqual(today.Month.ToString(), routeData.Values["mois"]);
            Assert.AreEqual(today.Year.ToString(), routeData.Values["annee"]);
        }

        private static RouteData DefinirUrl(string url)
        {
            var mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
           return routes.GetRouteData(mockContext.Object);
        }
    }
}
