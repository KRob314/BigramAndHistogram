using BigramAndHistogram.Services;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
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

        public string GetOutput(List<Bigram> bigrams)
        {
            StringBuilder sb = new StringBuilder();

            foreach(Bigram b in bigrams)
            {
                sb.AppendFormat("{0} {1} </br>", HttpContext.Current.Server.HtmlEncode(b.Phrase), b.Count);
            }

            return sb.ToString();
        }

        public string[] SplitWords(string input)
        {
            string result = input.Replace(System.Environment.NewLine, " ").ToLower().Trim();
            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            result = rgx.Replace(result, "");

            return result.Split(' ');
        }

        public List<Bigram> GetSequence(string[] words)
        {
            List<Bigram> bigrams = new List<Bigram>();

            for (int i = 0; i < words.Length - 1; i++)
            {
                Bigram bigram = new Bigram()
                {
                    Phrase = words[i] + " " + words[i + 1]
                };

                var matches = bigrams.Where(p => p.Phrase == bigram.Phrase).Count();

                if (matches == 0)
                {
                    bigram.Count = 1;
                    bigrams.Add(bigram);
                }
                else
                {
                    int bigramToEdit = bigrams.IndexOf(bigrams.Where(b => b.Phrase == bigram.Phrase).FirstOrDefault());
                    bigrams[bigramToEdit].Count += 1;
                }
            }

            return bigrams;
        }
    }
}