using System;
using System.Collections.Generic;
using System.Linq;

namespace Quotes
{
    internal class MyQuotes
    {
        #region Local Variables and Properties

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

        #endregion

        #region Constructor

        public MyQuotes()
        {
            loadQuotes();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Load the text file containing the quotes
        /// </summary>
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

        #endregion
    }
}