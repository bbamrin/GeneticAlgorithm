using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MyCurse.Contracts;
using MyCurse.Controller;
using MyCurse.Model;
using MyCurse.Utils;

namespace MyCurse
{
	public partial class Form1 : Form, ISubscriber
	{

		private GeneticController geneticController;
		private List<BitIndividual> bestInds;
		private List<BitIndividual> averageInds;
		private List<BitIndividual> worstInds;
		private List<BitIndividual> bestIndsBackup;
		private List<BitIndividual> averageIndsBackup;
		private List<BitIndividual> worstIndsBackup;
		private int logType = -1;
		private bool success = true;
		private bool isAlgFinished = false;
		private bool isAnimationFinished = true;


		public Form1()
		{
			InitializeComponent();
		}

		public SeriesCollection SCollection { get { return geneticChart.Series; } }

		private void clearChart()
		{
			geneticChart.Series[0].Points.Clear();
			geneticChart.Series[1].Points.Clear();
			geneticChart.Series[2].Points.Clear();
			geneticChart.Series[3].Points.Clear();
			bestInds.Clear();
			averageInds.Clear();
			worstInds.Clear();
			bestIndsBackup.Clear();
			averageIndsBackup.Clear();
			worstIndsBackup.Clear();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ColumnHeader logHeader = new ColumnHeader();

			geneticController = new GeneticController(this);
			bestInds = new List<BitIndividual>();
			averageInds = new List<BitIndividual>();
			worstInds = new List<BitIndividual>();
			bestIndsBackup = new List<BitIndividual>();
			averageIndsBackup = new List<BitIndividual>();
			worstIndsBackup = new List<BitIndividual>();
			LogListView.Columns.Add(logHeader);
			LogListView.Scrollable = true;
			LogListView.HeaderStyle = ColumnHeaderStyle.None;
			LogListView.View = View.Details;
			LogListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			geneticChart.ChartAreas[0].AxisX.ScaleView.Zoom(0, 50);
			geneticChart.ChartAreas[0].CursorX.IsUserEnabled = true;
			geneticChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
			geneticChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
			geneticChart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void LogListView_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void ClearLogsButton_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem i in LogListView.Items)
				i.Remove();
		}

		private void geneticStartButton_Click(object sender, EventArgs e)
		{
			if (!isAnimationFinished)
			{
				MessageBox.Show("Please wait until animation will be finished");
				return;
			}
			isAlgFinished = false;
			clearChart();
			try { geneticController.BestIndividualDefined(BestIndividualTextBox.Text); }
			catch (ArgumentOutOfRangeException) { WrongInputFormatNotification();  return; }
			for (int i = 0; i < (int)EpochNumeric.Value; ++i)
				geneticChart.Series[3].Points.Add(new DataPoint(i, BestIndividualTextBox.Text.Length));
			geneticController.PopulationDefined((int)PopulationNumeric.Value);
			geneticController.MutationDefined((int)MutationNumeric.Value);
			geneticController.EpochDefined((int)EpochNumeric.Value);
			this.geneticController.GeneticStarted();
		}

		public void NewBestIndividualNotification(BitIndividual ind)
		{
			bestInds.Add(ind);
			bestIndsBackup.Add(ind);
		}

		public void NewWorstIndividualNotification(BitIndividual ind)
		{
			worstInds.Add(ind);
			worstIndsBackup.Add(ind);
		}

		public void NewAverageIndividualNotification(BitIndividual ind)
		{
			averageInds.Add(ind);
			averageIndsBackup.Add(ind);
		}
		
		public void WrongInputFormatNotification()
		{
			MessageBox.Show(Constants.Messages.WRONG_FORMAT_MSG);
		}

		private void BestIndividualButton_Click(object sender, EventArgs e)
		{
			geneticController.BestIndividualDefined(BestIndividualTextBox.Text);
		}

		private void geneticChart_Click(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (isAlgFinished)
			{
				if (bestInds.Count == 0)
				{
					this.isAnimationFinished = true;
					timer1.Enabled = false;
					if (success)
						MessageBox.Show("Best individual was found");
					else
						MessageBox.Show("Best individual wasn`t found");
					return;
				}
				geneticChart.Series[0].Points.Add(new DataPoint((double)bestInds[0].Epoch, (double)bestInds[0].Fitness));
				geneticChart.Series[1].Points.Add(new DataPoint((double)averageInds[0].Epoch, (double)averageInds[0].Fitness));
				geneticChart.Series[2].Points.Add(new DataPoint((double)worstInds[0].Epoch, (double)worstInds[0].Fitness));
				if (logType == Constants.Integers.LOG_TYPE_BEST)
					LogListView.Items.Add("Epoch: " + bestInds[0].Epoch + " best: " + bestInds[0].GetChromosomeString() + "\n");
				else if (logType == Constants.Integers.LOG_TYPE_AVERAGE)
					LogListView.Items.Add("Epoch: " + averageInds[0].Epoch + " average: " + averageInds[0].GetChromosomeString() + "\n");
				else if (logType == Constants.Integers.LOG_TYPE_WORST)
					LogListView.Items.Add("Epoch: " + worstInds[0].Epoch + " worst: " + worstInds[0].GetChromosomeString() + "\n");
				bestInds.Remove(bestInds[0]);
				averageInds.Remove(averageInds[0]);
				worstInds.Remove(worstInds[0]);
			}
			
		}

		public void FirstPopulationProducingProgressChangedNotification()
		{
			EvolutionProgressBar.PerformStep();
		}

		public void FirstPopulationProducingFinishedNotification()
		{
			EvolutionProgressBar.Value = EvolutionProgressBar.Maximum;
			ProgressText.Text = "First population producing finished";
			ProgressText.Refresh();
		}

		public void EpochPassedNotification()
		{
			EvolutionProgressBar.PerformStep();
		}

		public void AlgorithmFinishedSucessfullyNotification()
		{
			EvolutionProgressBar.Value = EvolutionProgressBar.Maximum;
			ProgressText.Text = "Enter source data";
			ProgressText.Refresh();
			isAlgFinished = true;
			isAnimationFinished = false;
			success = true;
			timer1.Enabled = true;
		}

		public void AlgorithmStartedNotification(int progressMin, int progressMax, int step)
		{
			EvolutionProgressBar.Minimum = progressMin;
			EvolutionProgressBar.Maximum = progressMax;
			EvolutionProgressBar.Value = progressMin;
			EvolutionProgressBar.Step = step;
			ProgressText.Text = "Evolution in process";
			ProgressText.Refresh();
		}

		public void FirstPopulationProducingStartedNotification(int progressMin, int progressMax, int step)
		{
			EvolutionProgressBar.Minimum = progressMin;
			EvolutionProgressBar.Maximum = progressMax;
			EvolutionProgressBar.Value = progressMin;
			EvolutionProgressBar.Step = step;
			ProgressText.Text = "Population producing in process";
			ProgressText.Refresh();
		}

		public void AlgorithmFinishedUnsucessfullyNotification()
		{
			EvolutionProgressBar.Value = EvolutionProgressBar.Maximum;
			ProgressText.Text = "Enter source data";
			ProgressText.Refresh();
			isAlgFinished = true;
			isAnimationFinished = false;
			success = false;
			timer1.Enabled = true;
		}

		private void LogTypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (LogTypeBox.SelectedItem.ToString() == "Best individual")
				logType = Constants.Integers.LOG_TYPE_BEST;
			else if (LogTypeBox.SelectedItem.ToString() == "Average individual")
				logType = Constants.Integers.LOG_TYPE_AVERAGE;
			else if (LogTypeBox.SelectedItem.ToString() == "Worst individual")
				logType = Constants.Integers.LOG_TYPE_WORST;
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void SaveMenuItem_Click(object sender, EventArgs e)
		{
			//сериализация состояния программы и сохранение сериализованного объекта в файл
			if (!isAnimationFinished)
			{
				MessageBox.Show(Constants.Strings.ANIMATION_END);
				return;
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			FileStream fs;
			SerializableContainer container;
			StreamWriter writer;
			BinaryFormatter formatter;
			saveFileDialog.Filter = Constants.Strings.FILE_FORMAT;
			saveFileDialog.Title = "Save a Bit Genetic Algorithm File";
			saveFileDialog.ShowDialog();
			formatter = new BinaryFormatter();
			container = new SerializableContainer
				(
				this.bestIndsBackup,
				this.averageIndsBackup,
				this.worstIndsBackup,
				(int)PopulationNumeric.Value,
				(int)EpochNumeric.Value,
				MutationNumeric.Value,
				BestIndividualTextBox.Text,
				logType
				);
			
			if (saveFileDialog.FileName != "")
			{
				// Saves the Image via a FileStream created by the OpenFile method.
				fs = (FileStream)saveFileDialog.OpenFile();
				writer = new StreamWriter(fs);
				formatter.Serialize(fs, container);
				fs.Close();
			}
		}

		private void LoadMenuItem_Click(object sender, EventArgs e)
		{
			//десериализация состояния программы и восстановление состояния программы
			if (!isAnimationFinished)
			{
				MessageBox.Show(Constants.Strings.ANIMATION_END);
				return;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			SerializableContainer container;
			BinaryFormatter formatter = new BinaryFormatter();
			openFileDialog.InitialDirectory = "c:\\";
			openFileDialog.Filter = Constants.Strings.FILE_FORMAT;
			openFileDialog.FilterIndex = 1;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				clearChart();
				var fs = openFileDialog.OpenFile();
				foreach (ListViewItem i in LogListView.Items)
					i.Remove();
				container = (SerializableContainer)formatter.Deserialize(fs);
				this.logType = container.LogType;
				if (logType == Constants.Integers.LOG_TYPE_BEST)
					LogTypeBox.SelectedItem = "Best individual";
				else if (logType == Constants.Integers.LOG_TYPE_AVERAGE)
					LogTypeBox.SelectedItem = "Average individual";
				else if (logType == Constants.Integers.LOG_TYPE_WORST)
					LogTypeBox.SelectedItem = "Worst individual";
				this.EpochNumeric.Value = container.EpochCount;
				this.MutationNumeric.Value = container.MutationChance;
				this.PopulationNumeric.Value = container.PopSize;
				this.BestIndividualTextBox.Text = container.BestInd;
				this.bestIndsBackup = container.BestInds;
				this.averageIndsBackup = container.AverageInds;
				this.worstIndsBackup = container.WorstInds;
				for (int i = 0; i < container.BestInds.Count; ++i)
				{
					geneticChart.Series[0].Points.Add(new DataPoint((double)container.BestInds[i].Epoch, (double)container.BestInds[i].Fitness));
					geneticChart.Series[1].Points.Add(new DataPoint((double)container.AverageInds[i].Epoch, (double)container.AverageInds[i].Fitness));
					geneticChart.Series[2].Points.Add(new DataPoint((double)container.WorstInds[i].Epoch, (double)container.WorstInds[i].Fitness));
					if (logType == Constants.Integers.LOG_TYPE_BEST)
						LogListView.Items.Add("Epoch: " + container.BestInds[i].Epoch + " best: " + container.BestInds[i].GetChromosomeString() + "\n");
					else if (logType == Constants.Integers.LOG_TYPE_AVERAGE)
						LogListView.Items.Add("Epoch: " + container.AverageInds[i].Epoch + " average: " + container.AverageInds[i].GetChromosomeString() + "\n");
					else if (logType == Constants.Integers.LOG_TYPE_WORST)
						LogListView.Items.Add("Epoch: " + container.WorstInds[i].Epoch + " worst: " + container.WorstInds[i].GetChromosomeString() + "\n");
				}
				LogListView.Refresh();	
			}

		}
	}
}

