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
    }
}
