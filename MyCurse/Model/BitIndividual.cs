using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurse.Model
{
	[Serializable]
	public class BitIndividual
	{

		private List<BitGene> chromosome;
		private int epoch;
		private int fitness;

		public int Epoch { set { this.epoch = value; } get { return this.epoch; } }

		public int Fitness { set { this.fitness = value; } get { return this.fitness; } }

		public List<BitGene> Chromosome {
			get { return this.chromosome; }
			set {
				this.chromosome.Clear();
				foreach (BitGene g in value)
				{
					this.chromosome.Add(new BitGene(g.Value));
				}
			}
		}

		public String GetChromosomeString()
		{
			String s = "";

			foreach (BitGene g in this.chromosome)
				s += g.Value ? "1" : "0";
			return (s);
		}

		public BitIndividual(int epoch)
		{
			this.epoch = epoch;
			this.fitness = -1;
			this.chromosome = new List<BitGene>();
		}

		public BitIndividual(String str, int epoch) : this(epoch)
		{
			foreach (char c in str)
			{
				if (c != '1' && c != '0')
					return;
			}
			foreach (char c in str)
			{
				BitGene newGene = new BitGene(c);
				chromosome.Add(newGene);
			}
		}

		public BitIndividual(List<bool> lst, int epoch) : this(epoch)
		{
			foreach (bool b in lst)
			{
				BitGene newGene = new BitGene(b);
				chromosome.Add(newGene);
			}
		}

		public BitIndividual (List<BitGene> lst, int epoch) : this(epoch)
		{
			foreach (BitGene g in lst)
				chromosome.Add(new BitGene(g.Value));
		}

		public BitIndividual (BitIndividual ind) : this(ind.Chromosome, ind.epoch)
		{
			this.epoch = ind.epoch;
			this.fitness = ind.fitness;
		}
	}
}
