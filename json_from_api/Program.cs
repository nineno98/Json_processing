using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace json_from_api
{
    // python -m http.server 8000
    internal class Program
    {
        static void Main(string[] args)
        {
            //firstConnectToApi();

            var json = getJsonString().Result;
            Console.WriteLine(json);

            Console.ReadKey();
        }

        private static async Task<string> getJsonString()
        {
            string resJson = "";

            try
            {
                var url = "http://localhost:8000/";
                var api = "source.json";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response =  client.GetAsync(api).Result;
                resJson = await response.Content.ReadAsStringAsync();
                return resJson;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return resJson;
        }
        private static async void firstConnectToApi()
        {
            try
            {
                HttpClient client = new HttpClient();
                string url = "http://localhost:8000/";


                var response = await client.GetAsync(url);

                Console.WriteLine(response.StatusCode);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
