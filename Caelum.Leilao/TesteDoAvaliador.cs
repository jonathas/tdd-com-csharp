using System;

namespace Caelum.Leilao
{
	public class TesteDoAvaliador
	{
		static void Main(String[] args) 
		{
			Usuario joao = new Usuario ("Joao");
			Usuario jose = new Usuario ("Jose");
			Usuario maria = new Usuario ("Maria");

			Leilao leilao = new Leilao ("Playstation 3 Novo");

			leilao.Propoe (new Lance (joao, 300.0));
			leilao.Propoe (new Lance (jose, 400.0));
			leilao.Propoe (new Lance (maria, 250.0));

			Avaliador leiloeiro = new Avaliador ();
			leiloeiro.Avalia (leilao);

			Console.WriteLine (leiloeiro.MaiorLance);
			Console.WriteLine (leiloeiro.MenorLance);

			Console.ReadKey ();
		}
	}
}

