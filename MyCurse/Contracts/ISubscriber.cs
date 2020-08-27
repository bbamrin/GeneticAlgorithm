using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using MyCurse.Model;

namespace MyCurse.Contracts
{
	interface ISubscriber
	{
		void NewBestIndividualNotification(BitIndividual ind);
		void NewWorstIndividualNotification(BitIndividual ind);
		void NewAverageIndividualNotification(BitIndividual ind);
		void WrongInputFormatNotification();
		void FirstPopulationProducingProgressChangedNotification();
		void FirstPopulationProducingFinishedNotification();
		void EpochPassedNotification();
		void AlgorithmFinishedSucessfullyNotification();
		void AlgorithmFinishedUnsucessfullyNotification();
		void AlgorithmStartedNotification(int progressMin, int progressMax, int step);
		void FirstPopulationProducingStartedNotification(int progressMin, int progressMax, int step);
	}
}
