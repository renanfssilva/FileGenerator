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
        public async void Generate(string path, string text)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            string filename = String.Concat(path, "\\Generated File.txt");

            byte[] result = uniencoding.GetBytes(text);

            using (FileStream sourceStream = File.Open(filename, FileMode.OpenOrCreate))
            {
                sourceStream.SetLength(1048576); // Setting the maximum length to 1MB
                sourceStream.Seek(0, SeekOrigin.End);
                await sourceStream.WriteAsync(result, 0, result.Length);
            }
        }
    }
}
