using System;

namespace FileGenerator
{
    class Log
    {
        /// <summary>
        /// Number of iterations realized.
        /// </summary>
        public int iterations = 0;

        /// <summary>
        /// File generation total time.
        /// </summary>
        public TimeSpan fileGenerationTime;

        /// <summary>
        /// Write average time.
        /// </summary>
        public TimeSpan WriteAverageTime;

        /// <summary>
        /// File name.
        /// </summary>
        public string fileName;

        /// <summary>
        /// File size.
        /// </summary>
        public double fileSize;

        /// <summary>
        /// File path.
        /// </summary>
        public string filePath;

        /// <summary>
        /// Prints the log on console.
        /// </summary>
        public void ShowLog()
        {
            var elapsedFileGenerationTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                        fileGenerationTime.Hours, fileGenerationTime.Minutes, fileGenerationTime.Seconds,
                                                        fileGenerationTime.Milliseconds / 10);
            
            var elapsedWriteAverageTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                        WriteAverageTime.Hours, WriteAverageTime.Minutes, WriteAverageTime.Seconds,
                                                        WriteAverageTime.Milliseconds / 10);

            Console.WriteLine("\n--------------------------------------------" +
                              "\n               Execution Log                " +
                              "\nIterations realized: " + iterations +
                              "\nFile generation total time: " + elapsedFileGenerationTime +
                              "\nWrite average time: " + elapsedWriteAverageTime +
                              "\nFile name: " + fileName +
                              "\nFile size: " + fileSize +
                              "\nFile path: " + filePath +
                              "\n--------------------------------------------");
        }
    }
}
