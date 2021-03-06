﻿using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
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
            // Start StopWatch to get the total generation time
            var totalTimeStopwatch = new Stopwatch();
            totalTimeStopwatch.Start();

            var log = new Log();

            HtmlDocument loremIpzumHtmlDocument;
            string loremIpsum;

            string completeUrl;
            HtmlDocument byteCounterHtmlDocument;
            int bytes;

            // Generate file
            var generateFile = new GenerateFile();

            Console.WriteLine("Type the full path to the generated file (including file name and extension): ");
            var filePath = Console.ReadLine();
            while (String.IsNullOrEmpty(filePath))
            {
                log.iterations++;

                Console.WriteLine("\nThe file path is required. Type the full path, please.");
                filePath = Console.ReadLine();
            }

            log.fileName = Path.GetFileName(filePath);
            log.filePath = Path.GetDirectoryName(filePath);

            Console.WriteLine("\nType the buffer size, in Megabytes (leave it blank to be the default size '104,857,600 bytes' (100MB)): ");
            var bufferSizeString = Console.ReadLine();
            var bufferSize = String.IsNullOrEmpty(bufferSizeString) ? 104857600 : (Convert.ToInt32(bufferSizeString) * 1048576);

            while (log.fileSize < bufferSize)
            {
                log.iterations++;

                loremIpzumHtmlDocument = await StartCrawler(loremIpzumUrl);
                loremIpsum = GenerateText.GetLoremIpsum(loremIpzumHtmlDocument, log);

                completeUrl = String.Concat(calculateBytesUrl, loremIpsum);
                byteCounterHtmlDocument = await StartCrawler(completeUrl);
                bytes = ByteCounter.CalculateBytes(byteCounterHtmlDocument, loremIpsum);

                // Generate file
                generateFile.Generate(filePath, loremIpsum, bytes, bufferSize, log);
            }

            // Stop StopWatch to get the total generation time
            totalTimeStopwatch.Stop();
            log.fileGenerationTime = totalTimeStopwatch.Elapsed;

            // Prints log on console
            log.ShowLog();

            // Wait for a key to exit
            Console.WriteLine("\nFile generated. Press any key to exit...");
            Console.ReadKey();
        }

        /// <summary>
        /// Method that starts the Crawler
        /// </summary>
        /// <param name="url">String that holds the url to be 'crawled'.</param>
        /// <returns>Returns the HtmlDocument got by url.</returns>
        private static async Task<HtmlDocument> StartCrawler(string url)
        {
            var crawler = new Crawler();
            var htmlDocument = await crawler.StartCrawlerAsync(url);

            return htmlDocument;
        }
    }
}