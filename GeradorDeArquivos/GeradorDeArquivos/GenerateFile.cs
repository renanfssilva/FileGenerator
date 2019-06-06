using System;
using System.IO;
using System.Text;

namespace FileGenerator
{
    class GenerateFile
    {
        /// <summary>
        /// Method that generates the file given the path and the text.
        /// </summary>
        /// <param name="path">Path entered by the user.</param>
        /// <param name="text">Generated text.</param>
        public async void Generate(string path, string text, int bufferSize)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            string filename = String.Concat(path, "\\Generated File.txt");

            byte[] result = uniencoding.GetBytes(text);

            if (IsValidFilepath(filename))
            {
                using (FileStream sourceStream = File.Open(filename, FileMode.OpenOrCreate))
                {
                    sourceStream.SetLength(bufferSize); // Setting the maximum length to 1MB
                    sourceStream.Seek(0, SeekOrigin.End);
                    await sourceStream.WriteAsync(result, 0, result.Length);
                }
            }
            else
            {
                Console.WriteLine("Invalid file path.");
                Environment.Exit(1);
            }


        }

        private bool IsValidFilepath(string filepath)
        {
            System.IO.FileInfo fileInfo = null;

            try
            {
                fileInfo = new System.IO.FileInfo(filepath);
            }
            catch (ArgumentException) { }
            catch (System.IO.PathTooLongException) { }
            catch (NotSupportedException) { }

            if (fileInfo is null || !fileInfo.Exists)
            {
                Console.WriteLine("Invalid file path. Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(1);
            }

            return true;
        }
    }
}
