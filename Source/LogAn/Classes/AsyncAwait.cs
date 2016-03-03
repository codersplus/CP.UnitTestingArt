using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.Classes
{
    public class AsyncAwait
    {

        public static async Task<int> Divide(int numerator, int denominator)
        {

            await Task.Delay(10);
            return numerator / denominator;

        }

        public static async Task<string> ParseWebsiteUrlAsync(string url)
        {
            var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url);
        }
    }

}
