using System;
using Caelum.Leilao;
using NUnit.Framework;

namespace Caelum.Leilao
{
    [TestFixture]
    public class AvaliadorTest
    {
		[Test]
		public void DeveEntenderLancesEmOrdemCrescente() 
		{
			// 1ª parte: cenario
			Usuario joao = new Usuario ("Joao");
			Usuario jose = new Usuario ("Jose");
			Usuario maria = new Usuario ("Maria");

			Leilao leilao = new Leilao ("Playstation 3 Novo");

			leilao.Propoe (new Lance (maria, 250.0));
			leilao.Propoe (new Lance (joao, 300.0));
			leilao.Propoe (new Lance (jose, 400.0));

			// 2ª parte: acao
			Avaliador leiloeiro = new Avaliador ();
			leiloeiro.Avalia (leilao);

			// 3ª parte: validacao
			double maiorEsperado = 400;
			double menorEsperado = 250;

			Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance, 0.00001);
			Assert.AreEqual(menorEsperado, leiloeiro.MenorLance, 0.00001);
		}

        [Test]
        public void DeveCalcularMedia()
        {
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            Assert.AreEqual(317.0, leiloeiro.Media, 0.00001);
        }
	}
}

