using HtmlAgilityPack;
using System;
using System.Threading.Tasks;

namespace FileGenerator
{
    class Program
    {
        /// <summary>
        /// String that holds the api's url that generates lorem ipsum.
        /// </summary>
        private static readonly string loremIpzumUrl = "https://www.loremipzum.com/libraries/system/generate.php";

        /// <summary>
        /// String that holds the api's url that calculate bytes.
        /// </summary>
        private static readonly string calculateBytesUrl = "https://mothereff.in/byte-counter#";

        static async Task Main()
        {
            var loremIpzumHtmlDocument = await StartCrawler(loremIpzumUrl);
            var loremIpsum = GenerateText.GetLoremIpsum(loremIpzumHtmlDocument);

            var completeUrl = String.Concat(calculateBytesUrl, loremIpsum);
            var byteCounterHtmlDocument = await StartCrawler(completeUrl);
            var bytes = ByteCounter.CalculateBytes(byteCounterHtmlDocument, loremIpsum);

            Console.WriteLine("Digite o caminho do arquivo a ser salvo: ");
            var filePath = Console.ReadLine();

            var generateFile = new GenerateFile();
            generateFile.Generate(filePath, loremIpsum);

            //Console.WriteLine(bytes);

            // Wait for a key to exit
            Console.ReadKey();
        }

        private static async Task<HtmlDocument> StartCrawler(string url)
        {
            var crawler = new Crawler();
            var htmlDocument = await crawler.StartCrawlerAsync(url);

            return htmlDocument;
        }
    }
}