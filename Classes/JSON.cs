using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON_functions
{
    public static class JSON
    {
        private const string URL = "https://jsonplaceholder.typicode.com/posts/1";

        public static void CallJSONAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                string responseString;
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(URL)))
                {
                    
                    HttpResponseMessage response = client.SendAsync(request).Result;

                    // Get the response content as a string
                    responseString = response.Content.ReadAsStringAsync().Result;
                    
                    var o = JObject.Parse(responseString);

                    //Loop throgh all Values
                    foreach (var item in o)
                    {
                        System.Console.WriteLine(item.Value.ToString());
                    }
                    JToken value;
                    //Get a specific value
                    if (o.TryGetValue("userId", out value))
                    {
                        System.Console.WriteLine(value.ToString());
                    }

                    // Add a new Key>value
                    o.Add("Developer", "Lewis");
                    //Display new JSON Object
                    foreach (var item in o)
                    {
                        System.Console.WriteLine(item.Value.ToString());
                    }

                }

            }
        }
    }
}