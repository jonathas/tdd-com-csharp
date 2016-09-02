using NUnit.Framework;

namespace Caelum.Leilao.Tests
{
    [TestFixture]
    class LeilaoTest
    {
        private Usuario steveJobs;
        private Usuario steveWozniak;
        private Usuario billGates;

        [SetUp]
        public void SetUp()
        {
            steveJobs = new Usuario("Steve Jobs");
            steveWozniak = new Usuario("Steve Wozniak");
            billGates = new Usuario("Bill Gates");
        }

        [Test]
        public void DeveReceberUmLance()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15").Constroi();
            Assert.AreEqual(0, leilao.Lances.Count);

            leilao.Propoe(new Lance(new Usuario("Steve Jobs"), 2000));

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void DeveReceberVariosLances()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15")
                .Lance(steveJobs, 2000)
                .Lance(steveWozniak, 3000)
                .Constroi();

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
            Assert.AreEqual(3000, leilao.Lances[1].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15")
                .Lance(steveJobs, 2000)
                .Lance(steveJobs, 3000)
                .Constroi();

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(2000, leilao.Lances[0].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15")
                .Lance(steveJobs, 2000)
                .Lance(billGates, 3000)
                .Lance(steveJobs, 4000)
                .Lance(billGates, 5000)
                .Lance(steveJobs, 6000)
                .Lance(billGates, 7000)
                .Lance(steveJobs, 8000)
                .Lance(billGates, 9000)
                .Lance(steveJobs, 10000)
                .Lance(billGates, 11000)
                .Lance(steveJobs, 12000)
                .Constroi();

            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];

            Assert.AreEqual(11000, ultimoLance.Valor, 0.00001);
        }

        [Test]
        public void DeveDobrarUltimoLance() {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15")
                .Lance(steveJobs, 2000)
                .Lance(billGates, 3000)
                .Constroi();

            leilao.DobraLance(steveJobs);

            Assert.AreEqual(4000, leilao.Lances[2].Valor, 0.00001);
        }

        [Test]
        public void NaoDeveDobrarCasoNaoHajaLanceAnterior()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Macbook Pro 15").Constroi();

            leilao.DobraLance(steveJobs);

            Assert.AreEqual(0, leilao.Lances.Count);
        }
    }
}
