using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCurse.Model;
using MyCurse.Contracts;

namespace MyCurse.Controller
{
	class GeneticController
	{
		private GeneticModel geneticModel;

		public GeneticController(ISubscriber view)
		{
			geneticModel = GeneticModel.GetInstance;
			geneticModel.Algorithm.Subscribe(view);
		}

		public void GeneticStarted()
		{
			geneticModel.Algorithm.BitGeneticAlrorithm();
		}

		public void BestIndividualDefined (String ind)
		{
			geneticModel.Algorithm.BestIndividual = ind;
		}

		public void MutationDefined(Double mutation)
		{
			geneticModel.Algorithm.MutationProbability = mutation;
		}

		public void PopulationDefined(int populationSize)
		{
			geneticModel.Algorithm.PopulationSize = populationSize;
		}

		public void EpochDefined(int epochCount)
		{
			geneticModel.Algorithm.MaxEpoch = epochCount;
		}
	}
}
