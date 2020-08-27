namespace MyCurse
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Button ClearLogsButton;
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.EvolutionProgressBar = new System.Windows.Forms.ProgressBar();
			this.geneticChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.LogListView = new System.Windows.Forms.ListView();
			this.geneticStartButton = new System.Windows.Forms.Button();
			this.EpochNumeric = new System.Windows.Forms.NumericUpDown();
			this.PopulationNumeric = new System.Windows.Forms.NumericUpDown();
			this.MutationNumeric = new System.Windows.Forms.NumericUpDown();
			this.MutationLabel = new System.Windows.Forms.Label();
			this.PopulationLabel = new System.Windows.Forms.Label();
			this.EpochLabel = new System.Windows.Forms.Label();
			this.BestIndividualTextBox = new System.Windows.Forms.TextBox();
			this.BestIndividualLabel = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.ProgressLabel = new System.Windows.Forms.Label();
			this.ProgressText = new System.Windows.Forms.Label();
			this.LogTypeBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			ClearLogsButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.geneticChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EpochNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PopulationNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MutationNumeric)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ClearLogsButton
			// 
			ClearLogsButton.Location = new System.Drawing.Point(872, 412);
			ClearLogsButton.Name = "ClearLogsButton";
			ClearLogsButton.Size = new System.Drawing.Size(603, 45);
			ClearLogsButton.TabIndex = 14;
			ClearLogsButton.Text = "Clear logs";
			ClearLogsButton.UseVisualStyleBackColor = true;
			ClearLogsButton.Click += new System.EventHandler(this.ClearLogsButton_Click);
			// 
			// EvolutionProgressBar
			// 
			this.EvolutionProgressBar.Location = new System.Drawing.Point(872, 568);
			this.EvolutionProgressBar.Margin = new System.Windows.Forms.Padding(4);
			this.EvolutionProgressBar.Name = "EvolutionProgressBar";
			this.EvolutionProgressBar.Size = new System.Drawing.Size(603, 28);
			this.EvolutionProgressBar.TabIndex = 3;
			// 
			// geneticChart
			// 
			chartArea1.AxisX.Title = "Epoch";
			chartArea1.AxisY.Title = "Fitness Function";
			chartArea1.Name = "ChartArea1";
			this.geneticChart.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.geneticChart.Legends.Add(legend1);
			this.geneticChart.Location = new System.Drawing.Point(34, 45);
			this.geneticChart.Name = "geneticChart";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			series1.Legend = "Legend1";
			series1.Name = "Best Individual";
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series2.Color = System.Drawing.Color.Yellow;
			series2.Legend = "Legend1";
			series2.Name = "Average Individual";
			series3.ChartArea = "ChartArea1";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
			series3.Color = System.Drawing.Color.Red;
			series3.Legend = "Legend1";
			series3.Name = "Worst Individual";
			series4.ChartArea = "ChartArea1";
			series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series4.LabelForeColor = System.Drawing.Color.Gold;
			series4.Legend = "Legend1";
			series4.Name = "Best Fitness Function Value";
			this.geneticChart.Series.Add(series1);
			this.geneticChart.Series.Add(series2);
			this.geneticChart.Series.Add(series3);
			this.geneticChart.Series.Add(series4);
			this.geneticChart.Size = new System.Drawing.Size(798, 331);
			this.geneticChart.TabIndex = 4;
			this.geneticChart.Text = "chart1";
			this.geneticChart.Click += new System.EventHandler(this.geneticChart_Click);
			// 
			// LogListView
			// 
			this.LogListView.HideSelection = false;
			this.LogListView.Location = new System.Drawing.Point(872, 45);
			this.LogListView.Name = "LogListView";
			this.LogListView.Size = new System.Drawing.Size(603, 331);
			this.LogListView.TabIndex = 13;
			this.LogListView.UseCompatibleStateImageBehavior = false;
			this.LogListView.View = System.Windows.Forms.View.List;
			this.LogListView.SelectedIndexChanged += new System.EventHandler(this.LogListView_SelectedIndexChanged);
			// 
			// geneticStartButton
			// 
			this.geneticStartButton.Location = new System.Drawing.Point(872, 469);
			this.geneticStartButton.Name = "geneticStartButton";
			this.geneticStartButton.Size = new System.Drawing.Size(603, 55);
			this.geneticStartButton.TabIndex = 15;
			this.geneticStartButton.Text = "Start";
			this.geneticStartButton.UseVisualStyleBackColor = true;
			this.geneticStartButton.Click += new System.EventHandler(this.geneticStartButton_Click);
			// 
			// EpochNumeric
			// 
			this.EpochNumeric.Location = new System.Drawing.Point(174, 455);
			this.EpochNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.EpochNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.EpochNumeric.Name = "EpochNumeric";
			this.EpochNumeric.Size = new System.Drawing.Size(92, 22);
			this.EpochNumeric.TabIndex = 16;
			this.EpochNumeric.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
			// 
			// PopulationNumeric
			// 
			this.PopulationNumeric.Location = new System.Drawing.Point(174, 427);
			this.PopulationNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.PopulationNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.PopulationNumeric.Name = "PopulationNumeric";
			this.PopulationNumeric.Size = new System.Drawing.Size(92, 22);
			this.PopulationNumeric.TabIndex = 17;
			this.PopulationNumeric.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			// 
			// MutationNumeric
			// 
			this.MutationNumeric.DecimalPlaces = 2;
			this.MutationNumeric.Location = new System.Drawing.Point(174, 399);
			this.MutationNumeric.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MutationNumeric.Name = "MutationNumeric";
			this.MutationNumeric.Size = new System.Drawing.Size(92, 22);
			this.MutationNumeric.TabIndex = 18;
			this.MutationNumeric.Value = new decimal(new int[] {
            8,
            0,
            0,
            131072});
			// 
			// MutationLabel
			// 
			this.MutationLabel.AutoSize = true;
			this.MutationLabel.Location = new System.Drawing.Point(21, 401);
			this.MutationLabel.Name = "MutationLabel";
			this.MutationLabel.Size = new System.Drawing.Size(135, 17);
			this.MutationLabel.TabIndex = 24;
			this.MutationLabel.Text = "Mutation probability:";
			// 
			// PopulationLabel
			// 
			this.PopulationLabel.AutoSize = true;
			this.PopulationLabel.Location = new System.Drawing.Point(21, 429);
			this.PopulationLabel.Name = "PopulationLabel";
			this.PopulationLabel.Size = new System.Drawing.Size(108, 17);
			this.PopulationLabel.TabIndex = 25;
			this.PopulationLabel.Text = "Population size:";
			// 
			// EpochLabel
			// 
			this.EpochLabel.AutoSize = true;
			this.EpochLabel.Location = new System.Drawing.Point(21, 457);
			this.EpochLabel.Name = "EpochLabel";
			this.EpochLabel.Size = new System.Drawing.Size(91, 17);
			this.EpochLabel.TabIndex = 26;
			this.EpochLabel.Text = "Epoch count:";
			// 
			// BestIndividualTextBox
			// 
			this.BestIndividualTextBox.Location = new System.Drawing.Point(174, 485);
			this.BestIndividualTextBox.Name = "BestIndividualTextBox";
			this.BestIndividualTextBox.Size = new System.Drawing.Size(92, 22);
			this.BestIndividualTextBox.TabIndex = 27;
			this.BestIndividualTextBox.Text = "00101101110000000011111110001101001";
			// 
			// BestIndividualLabel
			// 
			this.BestIndividualLabel.AutoSize = true;
			this.BestIndividualLabel.Location = new System.Drawing.Point(21, 488);
			this.BestIndividualLabel.Name = "BestIndividualLabel";
			this.BestIndividualLabel.Size = new System.Drawing.Size(147, 17);
			this.BestIndividualLabel.TabIndex = 29;
			this.BestIndividualLabel.Text = "Individual to evolve in:";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 17);
			this.label1.TabIndex = 30;
			this.label1.Text = "label1";
			// 
			// ProgressLabel
			// 
			this.ProgressLabel.Location = new System.Drawing.Point(0, 0);
			this.ProgressLabel.Name = "ProgressLabel";
			this.ProgressLabel.Size = new System.Drawing.Size(100, 23);
			this.ProgressLabel.TabIndex = 33;
			// 
			// ProgressText
			// 
			this.ProgressText.AutoSize = true;
			this.ProgressText.Location = new System.Drawing.Point(1118, 538);
			this.ProgressText.Name = "ProgressText";
			this.ProgressText.Size = new System.Drawing.Size(121, 17);
			this.ProgressText.TabIndex = 32;
			this.ProgressText.Text = "Enter source data";
			// 
			// LogTypeBox
			// 
			this.LogTypeBox.FormattingEnabled = true;
			this.LogTypeBox.Items.AddRange(new object[] {
            "Best individual",
            "Average individual",
            "Worst individual"});
			this.LogTypeBox.Location = new System.Drawing.Point(1329, 382);
			this.LogTypeBox.Name = "LogTypeBox";
			this.LogTypeBox.Size = new System.Drawing.Size(146, 24);
			this.LogTypeBox.TabIndex = 34;
			this.LogTypeBox.Text = "Select Log Type";
			this.LogTypeBox.SelectedIndexChanged += new System.EventHandler(this.LogTypeBox_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1256, 385);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 17);
			this.label3.TabIndex = 36;
			this.label3.Text = "Log type:";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(212, 52);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 24);
			this.toolStripMenuItem1.Text = "toolStripMenuItem1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1512, 28);
			this.menuStrip1.TabIndex = 38;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem1
			// 
			this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveMenuItem,
            this.LoadMenuItem});
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem1.Text = "File";
			// 
			// SaveMenuItem
			// 
			this.SaveMenuItem.Name = "SaveMenuItem";
			this.SaveMenuItem.Size = new System.Drawing.Size(117, 26);
			this.SaveMenuItem.Text = "Save";
			this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
			// 
			// LoadMenuItem
			// 
			this.LoadMenuItem.Name = "LoadMenuItem";
			this.LoadMenuItem.Size = new System.Drawing.Size(117, 26);
			this.LoadMenuItem.Text = "Load";
			this.LoadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1512, 663);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.LogTypeBox);
			this.Controls.Add(this.ProgressText);
			this.Controls.Add(this.ProgressLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BestIndividualLabel);
			this.Controls.Add(this.BestIndividualTextBox);
			this.Controls.Add(this.EpochLabel);
			this.Controls.Add(this.PopulationLabel);
			this.Controls.Add(this.MutationLabel);
			this.Controls.Add(this.MutationNumeric);
			this.Controls.Add(this.PopulationNumeric);
			this.Controls.Add(this.EpochNumeric);
			this.Controls.Add(this.geneticStartButton);
			this.Controls.Add(ClearLogsButton);
			this.Controls.Add(this.LogListView);
			this.Controls.Add(this.geneticChart);
			this.Controls.Add(this.EvolutionProgressBar);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.geneticChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EpochNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PopulationNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MutationNumeric)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ProgressBar EvolutionProgressBar;
		private System.Windows.Forms.DataVisualization.Charting.Chart geneticChart;
		private System.Windows.Forms.ListView LogListView;
		private System.Windows.Forms.Button geneticStartButton;
		private System.Windows.Forms.NumericUpDown EpochNumeric;
		private System.Windows.Forms.NumericUpDown PopulationNumeric;
		private System.Windows.Forms.NumericUpDown MutationNumeric;
		private System.Windows.Forms.Label MutationLabel;
		private System.Windows.Forms.Label PopulationLabel;
		private System.Windows.Forms.Label EpochLabel;
		private System.Windows.Forms.TextBox BestIndividualTextBox;
		private System.Windows.Forms.Label BestIndividualLabel;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label ProgressLabel;
		private System.Windows.Forms.Label ProgressText;
		private System.Windows.Forms.ComboBox LogTypeBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LoadMenuItem;
	}
}

