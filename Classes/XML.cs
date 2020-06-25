using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml;

namespace XML_Functions
{
    public static class XML
    {
        private const string URL = "https://jsonplaceholder.typicode.com/posts/1";

        public static void CallJXMLAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                //string responseString;
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(URL)))
                {
                    HttpResponseMessage response = client.SendAsync(request).Result;

                    // Get the response content as a string                    
                    var xml = XDocument.Load(JsonReaderWriterFactory.CreateJsonReader(
                        Encoding.ASCII.GetBytes(response.Content.ReadAsStringAsync().Result),
                        new XmlDictionaryReaderQuotas()));

                    System.Console.WriteLine(xml);
                }
            }
        }
    }
}