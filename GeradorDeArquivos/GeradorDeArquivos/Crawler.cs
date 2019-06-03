using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    class Crawler
    {
        #region Internal Methods

        /// <summary>
        /// Asynchronous method to initialize the crowler.
        /// </summary>
        /// <returns></returns>
        internal async Task<HtmlDocument> StartCrawlerAsync(string url)
        {
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();

            // Try to load the html
            try
            {
                htmlDocument.LoadHtml(html);
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
