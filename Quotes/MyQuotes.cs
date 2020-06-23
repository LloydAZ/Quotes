using System;
using System.Collections.Generic;
using System.Linq;

namespace Quotes
{
    internal class MyQuotes
    {
        private List<string> quoteList = new List<string>();

        public string getQuote
        {
            get
            {
                Random random = new Random();
                int rnd = random.Next(0, quoteList.Count());
                return quoteList[rnd];
            }
        }

        public MyQuotes()
        {
            loadQuotes();
        }

        private void loadQuotes()
        {
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"Quotes.txt");

            while ((line = file.ReadLine()) != null)
            {
                quoteList.Add(line);
            }

            file.Close();
        }
    }
}