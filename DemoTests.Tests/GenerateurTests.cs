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
    public class GenerateurTests
    {
        [TestMethod]
        public void Generateur_AvecUnBouchon_Retourne5()
        {
            var mock = new Mock<IGenerateur>();
            mock.Setup(i => i.Valeur).Returns(5);

            Assert.AreEqual(5, mock.Object.Valeur);
        }
    }
}
