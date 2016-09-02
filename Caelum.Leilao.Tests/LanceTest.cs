using System;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class LanceTest
    {
        private Lance lance;
        private Usuario joao;

        [SetUp]
        public void SetUp()
        {
            joao = new Usuario("Joao");
        }

        [Test]
        public void DeveLancarExcecaoCasoValorSeja0()
        {
            Assert.That(() => lance = new Lance(joao, 0), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void DeveLancarExcecaoCasoValorSejaNegativo()
        {
            Assert.That(() => lance = new Lance(joao, -1), Throws.TypeOf<ArgumentException>());
        }

    }
}
