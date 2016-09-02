using System.Collections.Generic;
using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    public class FiltroDeLancesTest
    {
        private Usuario joao;
        private FiltroDeLances filtro;

        [SetUp]
        public void SetUp()
        {
            joao = new Usuario("Joao");
            filtro = new FiltroDeLances();
        }

        [Test]
        public void DeveSelecionarLancesEntre1000E3000()
        {
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao, 2000),
                new Lance(joao, 1000),
                new Lance(joao, 3000),
                new Lance(joao, 800)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(2000, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesEntre500E700()
        {
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao, 600),
                new Lance(joao, 500),
                new Lance(joao, 700),
                new Lance(joao, 800)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(600, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveSelecionarLancesMaioresQue5000()
        {
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao, 5001),
                new Lance(joao, 5000),
                new Lance(joao, 4000),
                new Lance(joao, 3000)
            });

            Assert.AreEqual(1, resultado.Count);
            Assert.AreEqual(5001, resultado[0].Valor, 0.00001);
        }

        [Test]
        public void DeveIgnorarLancesEntre3000E5000()
        {
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao, 3000),
                new Lance(joao, 4000),
                new Lance(joao, 5000),
                new Lance(joao, 4500)
            });

            Assert.AreEqual(0, resultado.Count);
        }

        [Test]
        public void DeveIgnorarLancesMenoresOuIguaisA500()
        {
            IList<Lance> resultado = filtro.Filtra(new List<Lance>() {
                new Lance(joao, 500),
                new Lance(joao, 400),
                new Lance(joao, 300),
                new Lance(joao, 10)
            });

            Assert.AreEqual(0, resultado.Count);
        }
    }
}
