using HtmlAgilityPack;
using System;
using System.Text;

namespace FileGenerator
{
    class GenerateText
    {
        #region Public Methods

        /// <summary>
        /// Get the generated text and formats it.
        /// </summary>
        /// <param name="htmlDocument">HTML Document already parsed.</param>
        /// <param name="log">Log object to manipulate time and iterations.</param>
        /// <returns>Returns the formatted text.</returns>
        public static string GetLoremIpsum(HtmlDocument htmlDocument, Log log)
        {
            Console.WriteLine("Generating text...\n");
            // Verifies if the text is usable
            if (!String.IsNullOrEmpty(htmlDocument.Text))
            {
                var generatedText = htmlDocument.Text;

                // Remove <p> notations from text
                generatedText = generatedText.Replace("</p><p>", "\n");
                generatedText = generatedText.Remove(generatedText.IndexOf("<p>"), 3);
                generatedText = generatedText.Remove(generatedText.IndexOf("</p>"), 4);

                return generatedText.Trim();
            }

            // If the generated text is null or empty, create a random string to use instead.
            return RandomString(log);
        }

        /// <summary>
        /// Generate a random string.
        /// </summary>
        /// <param name="log">Log object to manipulate time and iterations.</param>
        /// <returns>Returns a random string.</returns>
        public static string RandomString(Log log)
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();

            // Randomize between the 26 letters and append 1024 times
            for (int i = 0; i < 1024; i++)
            {
                log.iterations++;
                stringBuilder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}
