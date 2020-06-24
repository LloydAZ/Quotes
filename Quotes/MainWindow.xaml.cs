using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Quotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Variables

        private MyQuotes quotes = new MyQuotes();
        private DateTime today = DateTime.Now;
        private DispatcherTimer dt = new DispatcherTimer();

        #endregion Private Variables

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();

            // Load a quote
            textBlockQuote.Text = quotes.getQuote;

            // Create the event handler for the DispatcherTimer and set the interval to run every hour then start it.
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 1, 0, 0, 0);
            dt.Start();
        }

        #endregion Constructor

        #region Event Handlers

        /// <summary>
        /// Clicking on the image, the text block, or the label will get a new quote.
        /// </summary>
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            textBlockQuote.Text = quotes.getQuote;
        }

        /// <summary>
        /// Shut down the DispatcherTimer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                dt.Stop();
            }
            catch
            {
                // Do nothing, the DispatcherTimer is not running.
            }
        }

        /// <summary>
        /// This event runs every hour to see if the day has changed.  If it has, then get a new quote and display it.
        /// </summary>
        private void dt_Tick(object sender, EventArgs e)
        {
            DateTime current = DateTime.Now;

            if (today.Day != current.Day)
            {
                today = current;
                textBlockQuote.Text = quotes.getQuote;
            }
        }

        #endregion Event Handlers
    }
}