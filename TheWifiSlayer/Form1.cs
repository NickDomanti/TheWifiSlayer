using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWifiSlayer
{
    public partial class Form1 : Form
    {
        private int _requestsCount = 0;
        private readonly HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++) 
                SendRequestsAsync();

            UpdateCountOnUIAsync();
        }

        private async void SendRequestsAsync()
        {
            while (true)
            {
                _ = _httpClient.GetAsync("https://google.com");
                _requestsCount++;

                await Task.Delay(10);
            }
        }

        private async void UpdateCountOnUIAsync()
        {
            while (true)
            {
                label2.Text = _requestsCount.ToString();

                await Task.Delay(10);
            }
        }
    }
}
