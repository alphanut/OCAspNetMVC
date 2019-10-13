using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTests.Tests
{
    [TestClass]
    public class MeteoTests
    {
        [TestMethod]
        public void ObtenirLaMeteoDuJour_AvecUnBouchon_RetourneSoleil()
        {
            var fausseMeteo = new Meteo { Temperature = 25, Temps = Temps.Soleil };
            var mock = new Mock<IDal>();
            mock.Setup(dal => dal.ObtenirLaMeteoDuJour()).Returns(fausseMeteo);

            var fausseDal = mock.Object;
            var meteo = fausseDal.ObtenirLaMeteoDuJour();

            Assert.AreEqual(25, meteo.Temperature);
            Assert.AreEqual(Temps.Soleil, meteo.Temps);
        }
    }
}
