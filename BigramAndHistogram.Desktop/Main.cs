using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            lblOutput.Text = "";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BigramService bigramService = new BigramService(_settings);
            var words = bigramService.SplitWords(txtInput.Text);
            List<Bigram> bigrams = bigramService.GetSequence(words);

            lblOutput.Text = string.Format("Input length: {0} \nWords Length {1}\n {2}", txtInput.Text.Length, words.Length, bigramService.GetOutput(bigrams));

            if (_settings.ShowBigramGraph == true)
            {
                setChart(bigrams);
            }
        }

        private void setChart(List<Bigram> bigrams)
        {
            GraphForm graphForm = new GraphForm();


            graphForm.Chart.Series.Clear();
            graphForm.Chart.Visible = true;
            Series series = new Series("bigrams");

            for (int i = 0; i < bigrams.Count; i++)
            {
                series.ChartArea = "MainChartArea";
                series.Points.AddXY(bigrams[i].Phrase, bigrams[i].Count);
                series.Points[i].ToolTip = bigrams[i].Phrase;
            }

            graphForm.Chart.Series.Add(series);

            int largestCount = bigrams.OrderByDescending(b => b.Count).Select(b => b.Count).FirstOrDefault();
            int yInterval = (int)Math.Ceiling((double)largestCount * .10);
            graphForm.Chart.ChartAreas["MainChartArea"].AxisY.Interval = yInterval;

            graphForm.Show();

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(_settings);
            settingsForm.ShowDialog(this);
        }
    }

    public class BigramSettings
    {
        public bool FilterPunctuation { get; set; }
        public bool FilterNumbers { get; set; }

        public bool ShowBigramGraph { get; set; }
        public bool OrderList { get; set; }

        public BigramSettings()
        {
            ShowBigramGraph = false;
        }
    }
}
