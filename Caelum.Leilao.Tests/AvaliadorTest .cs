using System;
using Caelum.Leilao;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {

        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario maria;

        [OneTimeSetUp]
        public void TestandoBeforeClass()
        {
            Console.WriteLine("test fixture setup");
        }

        [OneTimeTearDown]
        public void TestandoAfterClass()
        {
            Console.WriteLine("test fixture tear down");
        }

        [SetUp]
        public void SetUp()
        {
            this.leiloeiro = new Avaliador();
            this.joao = new Usuario("Joao");
            this.jose = new Usuario("Jose");
            this.maria = new Usuario("Maria");
        }

        [TearDown]
        public void Finaliza()
        {
            Console.WriteLine("fim");
        }

        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Lance(maria, 250.0)
                .Lance(joao, 300)
                .Lance(jose, 400)
                .Constroi();

            leiloeiro.Avalia(leilao);

            double maiorEsperado = 400;
            double menorEsperado = 250;

            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.00001);
        }

        [Test]
        public void DeveCalcularMedia()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Lance(maria, 250.0)
                .Lance(joao, 300)
                .Lance(jose, 400)
                .Constroi();

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(317.0, leiloeiro.Media, 0.00001);
        }

        [Test]
        public void DeveEntenderLeilaoComApenasUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Lance(joao, 1000.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance, 0.0001);
            Assert.AreEqual(1000, leiloeiro.MenorLance, 0.0001);
        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Playstation")
                .Lance(joao, 100.0)
                .Lance(maria, 200.0)
                .Lance(joao, 300.0)
                .Lance(maria, 400.0)
                .Constroi();

            leiloeiro.Avalia(leilao);
            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor, 0.0001);
            Assert.AreEqual(300, maiores[1].Valor, 0.0001);
            Assert.AreEqual(200, maiores[2].Valor, 0.0001);
        }
	}
}

