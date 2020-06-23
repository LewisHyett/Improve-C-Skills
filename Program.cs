using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Improve_C_Skills
{
    class Program
    {

        private const string URL = "https://jsonplaceholder.typicode.com/posts/";
        static void Main(string[] args)
        {

            System.Console.WriteLine("Test");
            
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"");
                request.Content = new StringContent(URL, Encoding.UTF8,"application/json");

               


            }
        }
    }
}
