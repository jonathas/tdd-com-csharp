using System;
using System.Linq;

namespace Caelum.Leilao
{
	public class Avaliador
	{
		private double maiorDeTodos = Double.MinValue;
		private double menorDeTodos = Double.MaxValue;
        private double media = Double.MinValue;

		public void Avalia(Leilao leilao) 
		{
            media = Math.Round((from l in leilao.Lances select l.Valor).Average());

			foreach(var lance in leilao.Lances) {
				if(lance.Valor > maiorDeTodos) {
					maiorDeTodos = lance.Valor;
				}
				if (lance.Valor < menorDeTodos) {
					menorDeTodos = lance.Valor;
				}
			}
		}

		public double MaiorLance {
			get { return maiorDeTodos; }
		}

		public double MenorLance {
			get { return menorDeTodos; }
		}

        public double Media
        {
            get { return media; }
        }

	}
}

