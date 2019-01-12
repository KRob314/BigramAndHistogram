using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigramAndHistogram.Tests
{
    [TestClass]
    public class BigramTests
    {
        private BigramService bigramService = new BigramService();
        private string input; 


        [TestInitialize]
        public void Initialize()
        {
            BigramService bigramService = new BigramService();
            input = "The quick brown fox and the quick blue hare.";
        }

        [TestMethod]
        public void SplitWords_Returns_Array()
        {          
            
            string[] words = bigramService.SplitWords(input);

            Assert.AreEqual(9, words.Length);
        }

        [TestMethod]
        public void GetSequence_Returns_Sequence()
        {
            string[] words = bigramService.SplitWords(input);
            var bigrams = bigramService.GetSequence(words);

            Bigram bigram = bigrams[0];

            Assert.AreEqual(7, bigrams.Count);
            Assert.AreEqual("the quick", bigram.Phrase);
            Assert.AreEqual(2, bigram.Count);


        }

    }
}
