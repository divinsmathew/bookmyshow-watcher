using System;
using System.Media;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSWatcher
{
    public partial class BMSWatcher : Form
    {
        int Attempts = 0;
        long DataUsed = 0;
        public BMSWatcher()
        {
            InitializeComponent();
        }

        void Crap()
        {
            int InitCount = -1, Count;

            Task.Factory.StartNew(async delegate
            {
                while (true)
                {
                    using (WebClient client = new WebClient())
                    {
                        string Code = client.DownloadString("https://in.bookmyshow.com/buytickets/" + MovieID.Text);

                        if (InitCount == -1)
                            InitCount = Regex.Matches(Code, "<li class=\"list \"").Count;

                        Count = Regex.Matches(Code, "<li class=\"list \"").Count;

                        if (Count > InitCount)
                            new SoundPlayer(Properties.Resources.Police).Play();

                        Invoke(new Action(delegate
                        {
                            CountLabel.Text = "Theatre Count : " + Count.ToString();
                            LastCheckedLabel.Text = "Last Checked : " + DateTime.Now.ToString();
                            AttemptsLabel.Text = "Attempts : " + (++Attempts).ToString();
                        }));
                    }

                    await Task.Delay(5000);
                }
            });
        }

        private async void WatchButton_Click(object sender, EventArgs e)
        {
            WatchButton.Enabled = false;
            MovieID.Enabled = false;

            if (!await Verify())
            {
                WatchButton.Enabled = true;
                MovieID.Enabled = true;
                return;
            }

            Crap();

            WatchLabel.Visible = true;
            WatchButton.Visible = false;
            MovieID.Visible = false;
        }
        private async Task<bool> Verify()
        {
            if (string.IsNullOrWhiteSpace(MovieID.Text))
                return false;

            string Code = "";
            try
            {
                await Task.Run(delegate
                {
                    Code = new WebClient().DownloadString("https://in.bookmyshow.com/buytickets/" + MovieID.Text);
                });
            }
            catch
            {
                return false;
            }

            if (Code.IndexOf("cinema-name-wrapper") == -1)
                return false;

            for (int s = Code.IndexOf("\"name\" content=\"") + 16; Code[s + 2] != '/'; s++)
                WatchLabel.Text += Code[s];

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebBrowser b = new WebBrowser();
            b.ScriptErrorsSuppressed = true;
            b.DocumentCompleted += B_Navigated;

            b.Navigate("https://in.bookmyshow.com/kochi/movies/avengers-endgame/ET00090482");
        }

        private void B_Navigated(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var b = (WebBrowser)sender;
            DataUsed += b.DocumentText.Length;

            if (b.Document.GetElementById("user-wts-true") != null)
            {
                CountLabel.Text = "Data Used : " + Clean(DataUsed);
                LastCheckedLabel.Text = "Last Checked : " + DateTime.Now.ToString();
                AttemptsLabel.Text = "Attempts : " + (++Attempts).ToString();

                if (Attempts % 3 == 0 || Attempts % 2 == 0)
                    b.Navigate("https://in.bookmyshow.com/kochi/movies/avengers-endgame/ET00090482");
            }
            else
            {

                new SoundPlayer(Properties.Resources.Police).Play();
            }
        }

        private string Clean(long len)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (len == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(len);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(len) * num).ToString() + suf[place];
        }
    }
}
