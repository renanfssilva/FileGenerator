using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileGenerator
{
    class Crawler
    {
        #region Internal Methods

        /// <summary>
        /// Asynchronous method to initialize the crawler.
        /// </summary>
        /// <param name="urlString">String that holds the url.</param>
        /// <returns>Returns an HtmlDocument.</returns>
        internal async Task<HtmlDocument> StartCrawlerAsync(string urlString)
        {
            var httpClient = new HttpClient();
            var url = new Uri(urlString);
            var html = await httpClient.GetAsync(url);
            var htmlDocument = new HtmlDocument();

            // Try to load the html
            try
            {
                Console.WriteLine("Crawling...");
                if(html.IsSuccessStatusCode.Equals(true))
                {
                    var stringHtml = await httpClient.GetStringAsync(url);
                    htmlDocument.LoadHtml(stringHtml);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            httpClient.Dispose();
            return htmlDocument;
        }

        #endregion
    }
}
