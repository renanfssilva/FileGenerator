﻿using HtmlAgilityPack;
using System;

namespace FileGenerator
{
    class ByteCounter
    {
        #region Public Methods

        /// <summary>
        /// Method to calculate bytes using the byte counter API.
        /// </summary>
        /// <param name="htmlDocument">HTML Document already parsed.</param>
        /// <param name="loremIpsum">Generated text.</param>
        /// <returns></returns>
        public static int CalculateBytes(HtmlDocument htmlDocument, string loremIpsum)
        {
            Console.WriteLine("Calculating bytes...");

            if (!String.IsNullOrEmpty(htmlDocument.Text) && htmlDocument.GetElementbyId("bytes") != null)
            {
                string bytesText = htmlDocument.GetElementbyId("bytes").InnerText;
                return Convert.ToInt32(bytesText.Remove(bytesText.IndexOf(' ')));
            }

            return System.Text.Encoding.UTF8.GetByteCount(loremIpsum);
        }

        #endregion
    }
}
