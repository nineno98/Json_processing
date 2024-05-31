using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace json_from_api
{
    // python -m http.server 8000
    internal class Program
    {
        static void Main(string[] args)
        {
            firstConnectToApi();
            Console.ReadKey();
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
