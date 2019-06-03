using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace FileGenerator
{
    class GenerateFile
    {
        /// <summary>
        /// String that holds the api's url that generates lorem ipsum.
        /// </summary>
        private static readonly string loremIpzumUrl = "https://www.loremipzum.com/libraries/system/generate.php";

        /// <summary>
        /// String that holds the api's url that calculate bytes.
        /// </summary>
        private static readonly string calculateBytesUrl = "https://mothereff.in/byte-counter#";

        static async Task Main(string[] args)
        {
            var loremIpzumHtmlDocument = await StartCrawler(loremIpzumUrl);
            var loremIpsum = GenerateText.GetLoremIpsum(loremIpzumHtmlDocument);

            var byteCounterHtmlDocument = await StartCrawler(calculateBytesUrl + loremIpsum);
            var bytes = ByteCounter.CalculateBytes(byteCounterHtmlDocument);

            Console.WriteLine(bytes);

            // Wait for a key to exit
            Console.ReadKey();
        }

        private static async Task<HtmlDocument> StartCrawler(string url)
        {
            var crawler = new Crawler();
            var htmlDocument = new HtmlDocument();

            htmlDocument = await crawler.StartCrawlerAsync(url);

            return htmlDocument;
        }
    }
}