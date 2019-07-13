using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = string.Empty;
            string url = @"https://api.ipdata.co?api-key=";
            JObject jObject;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                jObject = JObject.Parse(html);
            }


            Console.WriteLine(jObject["languages"][0]["name"]);

            Console.Read();
        }

    }
}
