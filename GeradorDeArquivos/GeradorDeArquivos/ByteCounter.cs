using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileGenerator
{
    class ByteCounter
    {
        public static int CalculateBytes(HtmlDocument htmlDocument)
        {
            htmlDocument.GetElementbyId("bytes");

            return 1;
        }
    }
}
