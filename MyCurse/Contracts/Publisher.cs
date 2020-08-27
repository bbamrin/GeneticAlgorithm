using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using MyCurse.Model;

namespace MyCurse.Contracts
{
	abstract class Publisher
	{
		protected List<ISubscriber> subscribers;

		protected void NewBestIndividualNotify(BitIndividual ind)
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.NewBestIndividualNotification(ind);
		}

		protected void NewWorstIndividualNotify(BitIndividual ind)
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.NewWorstIndividualNotification(ind);
		}

		protected void NewAverageIndividualNotify(BitIndividual ind)
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.NewAverageIndividualNotification(ind);
		}

		protected void WrongInputFormatNotify()
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.WrongInputFormatNotification();
		}


		protected void AlgorithmStartedNotify(int progressMin, int progressMax, int step)
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.AlgorithmStartedNotification(progressMin, progressMax, step);
		}

		protected void FirstPopulationProducingStartedNotify(int progressMin, int progressMax, int step)
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.FirstPopulationProducingStartedNotification(progressMin, progressMax, step);
		}

		protected void FirstPopulationProducingProgressChangedNotify()
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.FirstPopulationProducingProgressChangedNotification();
		}

		protected void FirstPopulationProducingFinishedNotify()
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.FirstPopulationProducingFinishedNotification();
		}

		protected void EpochPassedNotify()
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.EpochPassedNotification();
		}

		protected void AlgorithmFinishedSucessfullyNotify()
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.AlgorithmFinishedSucessfullyNotification();
		}

		protected void AlgorithmFinishedUnsucessfullyNotify()
		{
			foreach (ISubscriber subscriber in subscribers)
				subscriber.AlgorithmFinishedUnsucessfullyNotification();
		}


		public void Subscribe(ISubscriber subscriber)
		{
			subscribers.Add(subscriber);
		}
		public void Unsubscribe(ISubscriber subscriber)
		{
			subscribers.Remove(subscriber);
		}
	}
}
