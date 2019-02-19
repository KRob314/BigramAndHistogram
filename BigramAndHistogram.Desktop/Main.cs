using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BigramAndHistogram.Desktop
{
    public partial class Main : Form
    {
        public BigramSettings _settings { get; set; }

        public Main()
        {
            InitializeComponent();
            _settings = new BigramSettings();
            txtOutput.Text = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            //BackgroundWorker worker = sender as BackgroundWorker;

            //BigramService bigramService = new BigramService(_settings);
            //var words = bigramService.SplitWords(txtInput.Text);
            //List<Bigram> bigrams = bigramService.GetSequence(words, worker);

            ////string output = bigramService.GetOutput(bigrams);
            //txtOutput.Text = string.Format("Input length: {0} {3}Words length: {1} {3}{2}", txtInput.Text.Length, words.Length, bigramService.GetOutput(bigrams), Environment.NewLine);

            //if (_settings.ShowBigramGraph == true)
            //{
            //    setBigramChart(bigrams);
            //}

            //if (_settings.ShowLetterFrequency == true)
            //{
            //    setLetterChart(bigramService.GetLetterFrequency());
            //    //var a = bigramService.GetLetterFrequency();
            //}

            //BigramService bigramService = new BigramService(_settings);
            //var result = bigramService.makeNgrams(txtInput.Text, 2);
            //StringBuilder sb = new StringBuilder();

            //var g = result.GroupBy(i => i);

            //foreach(var grp in g)
            //{
            //    sb.AppendFormat("{0} {1} {2}", grp.Key, grp.Count(), Environment.NewLine);
            //}


            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            //txtOutput.Text = string.Format("Input length: {0} {1}Runtime: {2}{1} {3}", txtInput.Text.Length,  Environment.NewLine, ts.TotalSeconds, sb.ToString());
        }

     

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(_settings);
            settingsForm.ShowDialog(this);
        }

        private void setBigramChart(List<Bigram> bigrams)
        {
            GraphForm graphForm = new GraphForm();


            graphForm.Chart.Series.Clear();
            graphForm.Chart.Visible = true;
            Series series = new Series("bigrams");
            series.ChartArea = "MainChartArea";

            for (int i = 0; i < bigrams.Count; i++)
            {
                series.Points.AddXY(bigrams[i].Phrase, bigrams[i].Count);
                series.Points[i].ToolTip = bigrams[i].Phrase;
            }

            graphForm.Chart.Series.Add(series);

            int largestCount = bigrams.OrderByDescending(b => b.Count).Select(b => b.Count).FirstOrDefault();
            int yInterval = (int)Math.Ceiling((double)largestCount * .10);
            graphForm.Chart.ChartAreas["MainChartArea"].AxisY.Interval = yInterval;

            graphForm.Show();

        }

        private void setLetterChart(Dictionary<string, double> letters)
        {
            GraphForm graphForm = new GraphForm();
            Dictionary<string, double> avgLetterFreq = new Dictionary<string, double>();
            avgLetterFreq.Add("A", 0.08167);
            avgLetterFreq.Add("B", 0.01492);
            avgLetterFreq.Add("C", 0.02782);
            avgLetterFreq.Add("D", 0.04253);
            avgLetterFreq.Add("E", 0.12702);
            avgLetterFreq.Add("F", 0.02228);
            avgLetterFreq.Add("G", 0.02015);
            avgLetterFreq.Add("H", 0.06094);
            avgLetterFreq.Add("I", 0.06966);
            avgLetterFreq.Add("J", 0.00153);
            avgLetterFreq.Add("K", 0.00772);
            avgLetterFreq.Add("L", 0.04025);
            avgLetterFreq.Add("M", 0.02406);
            avgLetterFreq.Add("N", 0.06749);
            avgLetterFreq.Add("O", 0.07507);
            avgLetterFreq.Add("P", 0.01929);
            avgLetterFreq.Add("Q", 0.00095);
            avgLetterFreq.Add("R", 0.05987);
            avgLetterFreq.Add("S", 0.06327);
            avgLetterFreq.Add("T", 0.09056);
            avgLetterFreq.Add("U", 0.02758);
            avgLetterFreq.Add("V", 0.00978);
            avgLetterFreq.Add("W", 0.0236);
            avgLetterFreq.Add("X", 0.0015);
            avgLetterFreq.Add("Y", 0.01974);
            avgLetterFreq.Add("Z", 0.00074);


            graphForm.Chart.Series.Clear();
            graphForm.Chart.Visible = true;
            Series series = new Series("Letter Frequency");
            series.ChartArea = "MainChartArea";

            foreach (KeyValuePair<string, double> kvp in letters)
            {
                series.Points.AddXY(kvp.Key, kvp.Value * 100);
            }

            graphForm.Chart.Series.Add(series);

            int largestCount = (int)letters.Values.Max();
            int yInterval = (int)Math.Ceiling((double)largestCount * .10);
            graphForm.Chart.ChartAreas["MainChartArea"].AxisY.Interval = yInterval;
            graphForm.Chart.ChartAreas["MainChartArea"].AxisX.Interval = 1;


            Series avgSeries = new Series("Avg English Letter Frequency");
            series.ChartArea = "MainChartArea";

            foreach (KeyValuePair<string, double> kvp in avgLetterFreq)
            {
                avgSeries.Points.AddXY(kvp.Key, kvp.Value * 100);
            }

            graphForm.Chart.Series.Add(avgSeries);

            graphForm.Show();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BackgroundWorker worker = sender as BackgroundWorker;

            BigramService bigramService = new BigramService(_settings);
            var words = bigramService.SplitWords(txtInput.Text);
            worker.ReportProgress(5);
            List<Bigram> bigrams = bigramService.GetSequence(words, worker);

            //string output = bigramService.GetOutput(bigrams);
          

            if (_settings.ShowBigramGraph == true)
            {
                setBigramChart(bigrams);
            }

            if (_settings.ShowLetterFrequency == true)
            {
                setLetterChart(bigramService.GetLetterFrequency());
                //var a = bigramService.GetLetterFrequency();
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;

            txtOutput.Text = string.Format("Input length: {0} {3}Words length: {1} {3}Runtime: {4} {3}{2}", txtInput.Text.Length, words.Length, bigramService.GetOutput(bigrams), Environment.NewLine, ts.TotalSeconds);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            txtOutput.Text = "Loading ... " + (e.ProgressPercentage.ToString() + "%");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                txtOutput.Text = "Canceled";
            }
            else if (e.Error != null)
            {
                txtOutput.Text = "Error: " + e.Error.Message;
            }
            else
            {
                txtOutput.Text += "Done";
            }
        }
    }

    public class BigramSettings
    {
        public bool FilterPunctuation { get; set; }
        public bool FilterNumbers { get; set; }

        public bool ShowBigramGraph { get; set; }
        public bool ShowLetterFrequency { get; set; }
        public bool OrderList { get; set; }

        public BigramSettings()
        {
            FilterNumbers = true;
            FilterPunctuation = true;
        }
    }

    /*runtime stats
    Input length: 463656 
    Words length: 84367 
    Runtime: 45.5049382 

    Input length: 463656 
    Words length: 84367 
    Runtime: 40.0744639 

    Input length: 463656 
    Words length: 84367 
    Runtime: 41.2193987 

    Input length: 912457 
    Words length: 159804 
    Runtime: 184.2771652 
     */
}
