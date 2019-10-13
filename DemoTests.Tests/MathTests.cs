using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoTests.Tests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void Factorielle_AvecValeur0_Retourne1()
        {
            var res = MathHelper.Factorielle(0);
            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void Factorielle_AvecValeur3_Retourne6()
        {
            var res = MathHelper.Factorielle(3);
            Assert.AreEqual(6, res);
        }

        [TestMethod]
        public void Factorielle_AvecValeur15_Retourne1307674368000()
        {
            var res = MathHelper.Factorielle(15);
            Assert.AreEqual(1307674368000, res);
        }
    }
}
