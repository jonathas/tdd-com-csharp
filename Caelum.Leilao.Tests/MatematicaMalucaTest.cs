using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class MatematicaMalucaTest
    {
        private MatematicaMaluca matematica;

        [SetUp]
        public void SetUp()
        {
            matematica = new MatematicaMaluca();
        }

        [Test]
        public void DeveMultiplicarNumerosMaioresQue30()
        {
            Assert.AreEqual(50 * 4, matematica.ContaMaluca(50));
        }

        [Test]
        public void DeveMultiplicarNumerosMaioresQue10EMenoresQue30()
        {
            Assert.AreEqual(20 * 3, matematica.ContaMaluca(20));
        }

        [Test]
        public void DeveMultiplicarNumerosMenoresQue10()
        {
            Assert.AreEqual(5 * 2, matematica.ContaMaluca(5));
        }
    }
}