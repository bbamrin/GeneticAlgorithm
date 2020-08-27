using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MyCurse.Contracts;
using MyCurse.Utils;

namespace MyCurse.Model
{
	//singleton
	sealed class GeneticModel
	{
		int state;
		private List<DataPoint> points;
		private static readonly object Instancelock = new object();
		private static GeneticModel genetic = null;
		private GeneticAlgorithm algorithm;

		private GeneticModel()
		{
			this.points = new List<DataPoint>();
			this.algorithm = new GeneticAlgorithm(100, 20, -1, 32);
		}

		public GeneticAlgorithm Algorithm { get { return this.algorithm; } }

		public static GeneticModel GetInstance
		{
			get
			{
				if (genetic == null)
				{
					lock(Instancelock)
					{
						if (genetic == null)
							genetic = new GeneticModel();
					}
				}
				return genetic;
			}
		}
	}
}
