using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FileGenerator
{
    class GenerateFile
    {
        #region Public Methods

        /// <summary>
        /// Method that generates the file given the path and the text.
        /// </summary>
        /// <param name="path">Path entered by the user.</param>
        /// <param name="text">Generated text.</param>
        /// <param name="textSize">Text size calculated.</param>
        /// <param name="bufferSize">Buffer size entered by user.</param>
        public void Generate(string path, string text, int textSize, int bufferSize, Log log)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            byte[] byteText = uniencoding.GetBytes(text);

            byte[] result = new byte[1048576];
            for (int i = 0; i < (1048576 / byteText.Length); i++)
            {
                log.iterations++;
                // Append the same text into file
                Buffer.BlockCopy(byteText, 0, result, i * byteText.Length, byteText.Length);
            }
            try
            {
                using (FileStream sourceStream = File.Open(path, FileMode.Append, FileAccess.Write))
                {
                    var writeTimeStopwatch = new Stopwatch();
                    writeTimeStopwatch.Start();

                    sourceStream.Write(result, 0, result.Length);

                    writeTimeStopwatch.Stop();
                    log.writeTimes.Add(writeTimeStopwatch.Elapsed);

                    log.fileSize = sourceStream.Length;
                }
            }
            catch (NotSupportedException) { }
            catch (ArgumentException)
            {
                Console.WriteLine("\nInvalid argument provided. Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(1);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("\nInvalid file path. Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(1);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("\nPath or file name is too long. Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        #endregion
    }
}
