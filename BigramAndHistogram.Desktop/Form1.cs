using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BigramAndHistogram.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblOutput.Text = "";
            BigramChart.Visible = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BigramService bigramService = new BigramService();
            var words = bigramService.SplitWords(txtInput.Text);
            List<Bigram> bigrams = bigramService.GetSequence(words);

            lblOutput.Text = bigramService.GetOutput(bigrams);

            setChart(bigrams);
        }

        private void setChart(List<Bigram> bigrams)
        {
            BigramChart.Series.Clear();
            BigramChart.Visible = true;
            Series series = new Series("bigrams");

            for (int i = 0; i < bigrams.Count; i++)
            {
                series.ChartArea = "MainChartArea";
                series.Points.AddXY(bigrams[i].Phrase, bigrams[i].Count);
                series.Points[i].ToolTip = bigrams[i].Phrase;
            }

            BigramChart.Series.Add(series);

            int largestCount = bigrams.OrderByDescending(b => b.Count).Select(b => b.Count).FirstOrDefault();
            int yInterval = (int)Math.Ceiling((double)largestCount * .10);
            BigramChart.ChartAreas["MainChartArea"].AxisY.Interval = yInterval;

        }
    }
}
