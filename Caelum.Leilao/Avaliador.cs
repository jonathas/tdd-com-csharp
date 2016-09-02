using System;
using System.Collections.Generic;
using System.Linq;

namespace Caelum.Leilao
{
	public class Avaliador
	{
		private double maiorDeTodos = Double.MinValue;
		private double menorDeTodos = Double.MaxValue;
        private double media = Double.MinValue;
        private List<Lance> maiores;

		public void Avalia(Leilao leilao) 
		{
            if(leilao.Lances.Count == 0)
            {
                throw new Exception("Nao eh possivel avaliar um leilao sem lances");
            }

            media = Math.Round((from l in leilao.Lances select l.Valor).Average());

			foreach(var lance in leilao.Lances) {
				if(lance.Valor > maiorDeTodos) {
					maiorDeTodos = lance.Valor;
				}
				if (lance.Valor < menorDeTodos) {
					menorDeTodos = lance.Valor;
				}
			}

            pegaOsMaioresNo(leilao);
		}

        private void pegaOsMaioresNo(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
            maiores = maiores.GetRange(0, maiores.Count > 3 ? 3 : maiores.Count);
        }

        public List<Lance> TresMaiores
        {
            get { return this.maiores; }
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

