using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCurse.Contracts;

namespace MyCurse.Model
{
	class GeneticAlgorithm : Publisher
	{

		private List<BitIndividual> population;
		private int populationSize;
		private int maxEpoch;
		private int chromosomeSize;
		private Double mutationProbability;
		private BitIndividual bestIndividual;
		private int geneCount;

		public Double MutationProbability { get { return this.mutationProbability; } set { this.mutationProbability = value; } }
		public int MaxEpoch { get { return this.maxEpoch; } set { this.maxEpoch = value; } }
		public int PopulationSize { get { return this.populationSize; } set { this.populationSize = value; } }
		public String BestIndividual
		{ set
			{
				if (value.Length == 0)
					throw new ArgumentOutOfRangeException();
				foreach (char c in value)
				{
					if (c != '0' && c != '1')
						throw new ArgumentOutOfRangeException();
				}
				this.bestIndividual = new BitIndividual(value, 0);
				this.geneCount = value.Length;
			}
		}

		
		public GeneticAlgorithm (int populationSize, int maxEpoch, Double mutationProbability, int geneCount)
		{
			this.mutationProbability = mutationProbability;
			this.maxEpoch = maxEpoch;
			this.populationSize = populationSize;
			this.geneCount = geneCount;
			this.population = new List<BitIndividual>();
			this.bestIndividual = new BitIndividual(GenerateBestBitVector(geneCount), 0);
			subscribers = new List<ISubscriber>();
		}

		private int FitnessFunction(BitIndividual ind)
		{
			int r = 0;
			for (int i = 0; i < ind.Chromosome.Count; ++i)
			{
				r += ind.Chromosome[i].Value == this.bestIndividual.Chromosome[i].Value ? 1 : 0;
			}
			return (r);
		}

		class DescendingGeneicComparer : IComparer<BitIndividual>
		{
			public int Compare(BitIndividual x, BitIndividual y)
			{
				if (x.Fitness < y.Fitness)
					return (1);
				else if (x.Fitness > y.Fitness)
					return (-1);
				else
					return (0);
			}
		}

		private List<BitGene> GenerateBestBitVector(int size)
		{
			List<BitGene> v = new List<BitGene>();
			for (int i = 0; i < size; ++i)
				v.Add(new BitGene(true));
			return v;
		}
		//алгоритм 21(генерация случайного битового вектора)
		private List<BitGene> GenerateRandomBitVector(int size)
		{
			List<BitGene> v = new List<BitGene>();
			Random random = new Random();
			Thread.Sleep(20);
			for (int i = 0; i < size; ++i)
			{
				if (0.5 > random.NextDouble())
					v.Add(new BitGene(false));
				else
					v.Add(new BitGene(true));
			}
			return v;
		}

		private List<BitIndividual> BitCrossover(List<BitIndividual> inds)
		{
			bool tmp;
			int cutPoint;

			if (inds.Count == 0)
				return (null);
			List<BitIndividual> newInds = new List<BitIndividual>();
			Random random = new Random();
			cutPoint = random.Next(0, inds[0].Chromosome.Count);
			for (int i = 0; i < inds.Count; ++i)
				newInds.Add(new BitIndividual(inds[i]));
			for (int i = 0; i <= cutPoint; ++i)
			{

				newInds[0].Chromosome[i].Value = inds[1].Chromosome[i].Value;
				newInds[1].Chromosome[i].Value = inds[0].Chromosome[i].Value; ;
			}
			return newInds;
		}

		private void Mutation(List<BitIndividual> inds, Double mutationProbability)
		{
			Random random = new Random();
			foreach (BitIndividual ind in inds)
			{
				for (int i = 0; i < ind.Chromosome.Count; ++i)
					if (mutationProbability >= random.NextDouble())
						ind.Chromosome[i].Value = !(ind.Chromosome[i].Value);
			}
		}

		private BitIndividual SelectWithReplacement(List<BitIndividual> population)
		{
			BitIndividual best = new BitIndividual(population[0]);
			population.Remove(population[0]);
			return best;
		}

		private void CalculatePopulationFitness(List<BitIndividual> population, int epoch)
		{
			foreach (BitIndividual ind in population)
			{
				ind.Fitness = FitnessFunction(ind);
				ind.Epoch = epoch;
			}
				
		}
		//алгоритм 20 (генетический алгоритм)
		public BitIndividual BitGeneticAlrorithm()
		{
			List<BitIndividual> parents, children;
			DescendingGeneicComparer c = new DescendingGeneicComparer();
			int epoch = -1;

			parents = new List<BitIndividual>();
			children = new List<BitIndividual>();
			this.population.Clear();
			FirstPopulationProducingStartedNotify(0, PopulationSize, 1);
			//создание первой популяции
			for (int i = 0; i < populationSize; ++i)
			{
				this.population.Add(new BitIndividual(GenerateRandomBitVector(geneCount), 0));
				//оповещение View об изменении в данных, т.е о добавлении нового индивида в популяцию
				FirstPopulationProducingProgressChangedNotify();
			}
			//оповещения View о конце создания первой популяции и начале работы самого алгоритма
			FirstPopulationProducingFinishedNotify();
			AlgorithmStartedNotify(0, maxEpoch, 1);
			this.bestIndividual.Fitness = FitnessFunction(this.bestIndividual);
			while (++epoch < this.maxEpoch)
			{
				//просчитывание функции приспособленности для каждого индивида данной эпохи
				CalculatePopulationFitness(this.population, epoch);
				//сортировка идивидов от лучшего к худшему для удобства работы с данными
				this.population.Sort(c);
				//производится определение среднего, худшего и лучшего индивидов, после чего происходит оповещение View 
				NewAverageIndividualNotify(this.population[this.population.Count / 2]);
				NewWorstIndividualNotify(this.population[this.population.Count - 1]);
				NewBestIndividualNotify(this.population[0]);
				List<BitIndividual> nextPopulation = new List<BitIndividual>();
				//производство новой популяции путем скрещивания индивидов из предыдущей популяции
				for (int i = 0; i < populationSize / 2; ++i)
				{
					parents.Clear();
					parents.Add(SelectWithReplacement(this.population));
					parents.Add(SelectWithReplacement(this.population));
					children.Clear();
					children = BitCrossover(parents);
					Mutation(children, mutationProbability);
					nextPopulation.Add(children[0]);
					nextPopulation.Add(children[1]);
				}
				this.population = nextPopulation;
				//оповещение View о прошествии эпохи
				EpochPassedNotify();
				//условие успешного выхода (то есть если в ходе алгоритма удалось найти лучшего индивида)
				if (this.population[0].Fitness == this.bestIndividual.Fitness)
				{
					AlgorithmFinishedSucessfullyNotify();
					return (this.population[0]);
				}
			}
			//оповещение о неудачном завершении алгоритма
			AlgorithmFinishedUnsucessfullyNotify();
			return (this.population[0]);
		}
	}
}
