using System;
using System.Collections.Generic;
using System.Linq;

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
        public TimeSpan writeAverageTime;

        /// <summary>
        /// Times that buffer was written on file.
        /// </summary>
        public List<TimeSpan> writeTimes = new List<TimeSpan>();

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
            var elapsedFileGenerationTime = String.Format("{0:00}:{1:00}:{2:00.0000}",
                                                        fileGenerationTime.Hours, fileGenerationTime.Minutes, fileGenerationTime.TotalSeconds);

            var averageTime = new TimeSpan((long)writeTimes.Select(ts => ts.Ticks).Average());

            var elapsedWriteAverageTime = String.Format("{0:00}:{1:00}:{2:00.0000}",
                                                        averageTime.Hours, averageTime.Minutes, averageTime.TotalSeconds);

            Console.WriteLine("\n--------------------------------------------" +
                              "\n               Execution Log                " +
                              "\nIterations realized: " + iterations +
                              "\nFile generation total time: " + elapsedFileGenerationTime +
                              "\nWrite average time: " + elapsedWriteAverageTime +
                              "\nFile name: " + fileName +
                              "\nFile size: " + fileSize + " bytes (" + fileSize / 1048576 + " MB)" +
                              "\nFile path: " + filePath +
                              "\n--------------------------------------------");
        }
    }
}
