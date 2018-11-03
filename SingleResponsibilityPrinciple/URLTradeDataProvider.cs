using SingleResponsibilityPrinciple.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    class URLTradeDataProvider : ITradeDataProvider
    {
        string url;

        /// <summary>
        /// Constructor for URLTradeDataProvider
        /// </summary>
        /// <param name="url">String url of a file containing the Trade Data</param>
        public URLTradeDataProvider(string url)
        {
            this.url = url;
        }

        /// <summary>
        /// Get trade data from text file in URL
        /// </summary>
        /// <returns>A list of trade data</returns>
        public IEnumerable<string> GetTradeData()
        {
            var tradeData = new List<string>();
            // create a web client and use it to read the file stored at the given URL
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tradeData.Add(line);
                }
            }
            return tradeData;
        }
    }
}
