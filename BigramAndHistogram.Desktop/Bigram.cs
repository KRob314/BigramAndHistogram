using BigramAndHistogram.Desktop;
using BigramAndHistogram.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BigramAndHistogram
{
    public class Bigram
    {
        public string Phrase { get; set; }
        public int Count { get; set; }
    }

    public class BigramService : IBigramService
    {
        private string input;
        public BigramSettings bigramSettings { get; set; }

        public BigramService(BigramSettings settings)
        {
            this.bigramSettings = settings;
        }

        public string GetOutput(List<Bigram> bigrams)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            StringBuilder sb = new StringBuilder();

            if (bigramSettings.OrderList == true)
            {
                bigrams = bigrams.OrderByDescending(b => b.Count).ToList();
            }

            foreach (Bigram b in bigrams)
            {
               sb.AppendFormat("{0} {1} {2}", b.Phrase, b.Count, Environment.NewLine);              
            }

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            return sb.ToString();
        }

        public string[] SplitWords(string input)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string result = input.Replace(System.Environment.NewLine, " ").Replace("\t", " ").ToLower().Trim();

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options); // more than 1 space between words, excludes new lines & tabs
            result = regex.Replace(result, " ");

            if (bigramSettings.FilterPunctuation == true)
            {
                regex = new Regex("[^a-zA-Z0-9 -]");
                result = regex.Replace(result, "");
            }

            if (bigramSettings.FilterNumbers == true)
            {
                regex = new Regex(@"[ˆ(\d|+|\-)]");
                result = regex.Replace(result, "");
            }

            this.input = result.ToUpper();

            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);

            return result.Split(' ');
        }


        public List<Bigram> GetSequence(string[] words, BackgroundWorker worker)
        {
            List<int> progressPoints = new List<int>()
            {
              Convert.ToInt32(words.Length * .15), Convert.ToInt32(words.Length * .30), Convert.ToInt32(words.Length * .45),
              Convert.ToInt32(words.Length * .60), Convert.ToInt32(words.Length * .75), Convert.ToInt32(words.Length * .90)
            };
        
             
            List<Bigram> bigrams = new List<Bigram>();
            List<string> bigramsTemp = new List<string>();

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (string.IsNullOrWhiteSpace(words[i]) == false)
                {
                    bigramsTemp.Add(words[i] + " " + words[i + 1]);

                    //Bigram bigram = new Bigram()
                    //{
                    //    Phrase = words[i] + " " + words[i + 1]
                    //};

                    //var matches = bigrams.Where(p => p.Phrase == bigram.Phrase).Count();

                    //if (matches == 0)
                    //{
                    //    bigram.Count = 1;
                    //    bigrams.Add(bigram);
                    //}
                    //else
                    //{
                    //    int bigramToEdit = bigrams.IndexOf(bigrams.FirstOrDefault(b => b.Phrase == bigram.Phrase));
                    //    bigrams[bigramToEdit].Count += 1;
                    //}
                }

                if(progressPoints.Contains(i))
                {
                    int progressIndex = progressPoints.IndexOf(i);
                    double percent = (double)i / words.Length * 100;
                    worker.ReportProgress((int)percent);
                }

            }

            var sequences = bigramsTemp.GroupBy(i => i);

            foreach (var s in sequences)
            {
                bigrams.Add(
                    new Bigram()
                    {
                        Phrase = s.Key,
                        Count = s.Count()
                    });
            }

            return bigrams;
        }

        public Dictionary<String, double> GetLetterFrequency()
        {
            Dictionary<string, int> letters = new Dictionary<string, int>();
            Dictionary<string, double> lettersFreq = new Dictionary<string, double>();
            int totalLetters = 0;

            for (int i = 65; i < 91; i++)
            {
                letters.Add(Microsoft.VisualBasic.Strings.Chr(i).ToString(), 0);
            }

            foreach (char c in input)
            {
                if (c < 91 && letters.ContainsKey(Microsoft.VisualBasic.Strings.Chr(c).ToString()))
                {
                    letters[Microsoft.VisualBasic.Strings.Chr(c).ToString()] += 1;
                    totalLetters += 1;
                }
            }

            foreach (KeyValuePair<string, int> kvp in letters)
            {
                double letterFrequency = (double)kvp.Value / totalLetters;
                lettersFreq.Add(kvp.Key, letterFrequency);
            }

            return lettersFreq;

        }
    }
}