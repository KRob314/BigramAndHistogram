using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;

namespace BigramAndHistogram
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            lblOutput.Text = "";
            pnl_output.Visible = true;

            BigramService bigramService = new BigramService();
            var words = bigramService.SplitWords(txtInput.InnerText);
            List<Bigram> bigrams = bigramService.GetSequence(words);
            Dictionary<char, int> letterCounts = bigramService.LetterFrequency(txtInput.InnerText.ToLower());
            lblOutput.Text = bigramService.GetOutput(bigrams);


            setChart(bigrams);
            setLetterFrequencyChart(letterCounts);

            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            lblOutput.Text += string.Format("Elapsed time: {0:00}:{1:00}", ts.Seconds, ts.Milliseconds);

    


        }

        private void setChart(List<Bigram> bigrams)
        {
            Series series = new Series("bigrams");

            for (int i = 0; i < bigrams.Count; i++)
            {
                series.ChartArea = "MainChartArea";
                series.Points.AddXY(bigrams[i].Phrase, bigrams[i].Count);
                series.Points[i].ToolTip = bigrams[i].Phrase;
            }

            //foreach (var b in bigrams)
            //{
            //    series.ChartArea = "MainChartArea";
            //    series.Points.AddXY(b.Phrase, b.Count);
            //    series.Points[0].ToolTip = "test";
            //}

            BigramChart.Series.Add(series);

            int largestCount = bigrams.OrderByDescending(b => b.Count).Select(b => b.Count).FirstOrDefault();
            int yInterval = (int)Math.Ceiling((double)largestCount * .10);
            BigramChart.ChartAreas["MainChartArea"].AxisY.Interval = yInterval;

        }

       private void setLetterFrequencyChart(Dictionary<char, int> letterCounts)
        {
            Series series = new Series("Letters");

            foreach(KeyValuePair<char, int> kvp in letterCounts)
            {
                series.ChartArea = "MainChartArea";
                series.Points.AddXY(kvp.Key.ToString(), kvp.Value);             
            }

            LetterFrequencyChart.Series.Add(series);
            LetterFrequencyChart.ChartAreas["MainChartArea"].AxisX.Interval = 1;
        }


    }
}