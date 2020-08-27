using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCurse.Model
{
	[Serializable]
	class SerializableContainer
	{
		private List<BitIndividual> bestInds;
		private List<BitIndividual> averageInds;
		private List<BitIndividual> worstInds;
		private int popSize;
		private int epochCount;
		private Decimal mutationChance;
		private String bestInd;
		private int logType;

		public List<BitIndividual> BestInds { get { return this.bestInds; }}
		public List<BitIndividual> AverageInds { get { return this.averageInds; } }
		public List<BitIndividual> WorstInds { get { return this.worstInds; } }
		public int PopSize { get { return this.popSize; } }
		public int EpochCount { get { return this.epochCount; } }
		public Decimal MutationChance { get { return this.mutationChance; } }
		public String BestInd { get { return this.bestInd; } }
		public int LogType { get { return this.logType; } }


		public SerializableContainer(
			List<BitIndividual> bestInds,
			List<BitIndividual> averageInds,
			List<BitIndividual> worstInds,
			int popSize,
			int epochCount,
			Decimal mutationChance,
			String bestInd,
			int logType
			)
		{
			this.bestInds = new List<BitIndividual>();
			this.averageInds = new List<BitIndividual>();
			this.worstInds = new List<BitIndividual>();
			foreach (BitIndividual i in bestInds)
				this.bestInds.Add(new BitIndividual(i));
			foreach (BitIndividual i in averageInds)
				this.averageInds.Add(new BitIndividual(i));
			foreach (BitIndividual i in worstInds)
				this.worstInds.Add(new BitIndividual(i));
			this.popSize = popSize;
			this.epochCount = epochCount;
			this.mutationChance = mutationChance;
			this.bestInd = bestInd;
			this.logType = logType;
		}
	}
}
