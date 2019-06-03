using HtmlAgilityPack;
using System;
using System.Collections.Generic;
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
        /// <returns>Returns the formatted text.</returns>
        public static string GetLoremIpsum(HtmlDocument htmlDocument)
        {
            // Verifies if the text is usable
            if (!String.IsNullOrEmpty(htmlDocument.Text))
            {
                var generatedText = htmlDocument.Text;

                // Remove <p> notations from text
                generatedText = generatedText.Replace("</p><p>", "%20");
                generatedText = generatedText.Remove(generatedText.IndexOf("<p>"), 3);
                generatedText = generatedText.Remove(generatedText.IndexOf("</p>"), 4);
                generatedText = generatedText.Replace(" ", "%20");

                return generatedText.Trim();
            }

            // If the generated text is null or empty, create a random string to use instead.
            return RandomString();
        }

        /// <summary>
        /// Generate a random string.
        /// </summary>
        /// <returns>Returns a random string.</returns>
        public static string RandomString()
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();

            // Randomize between the 26 letters and append 1024 times
            for (int i = 0; i < 1024; i++)
                stringBuilder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65))));

            return stringBuilder.ToString();
        }

        #endregion
    }
}
