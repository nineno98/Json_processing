﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace get_and_put_methods_with_jsonApi
{
    // GET: https://api-generator.retool.com/JbW1bY/employers
    // GET filter https://api-generator.retool.com/JbW1bY/employers?name=value
    // GET by id: https://api-generator.retool.com/JbW1bY/employers/1
    // GET paginate https://api-generator.retool.com/JbW1bY/employers?_page=2&_limit=10
    // POST: Content-Type: application/json' -d '{"key":"value"},
    // https://api-generator.retool.com/JbW1bY/employers
    // PUT: https://api-generator.retool.com/JbW1bY/employers/1
    // PATCH: https://api-generator.retool.com/JbW1bY/employers/1
    // DELETE: https://api-generator.retool.com/JbW1bY/employers/1

    /*
     * 
     * {
        "id": 1,
        "name": "Karalee Radleigh",
        "salary": 926
        }
     * 
     */
    internal class Program
    {
        static public List<Employer> Employers = new List<Employer>();
        static void Main(string[] args)
        {

            LoadEmployers();
            //TestConnection();

            foreach (var item in Employers)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        public static async void LoadEmployers()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://api-generator.retool.com/JbW1bY/employers");

                var response = client.GetAsync(client.BaseAddress).Result;
                var jsonResponse = await response.Content.ReadAsStringAsync();

                ProcessJsonString(jsonResponse);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        private static void ProcessJsonString(string jsonstring)
        {
            var jsonArray = JArray.Parse(jsonstring);
            foreach (var item in jsonArray)
            {
                Employer emp = JsonConvert.DeserializeObject<Employer>(item.ToString());
                Employers.Add(emp);
            }
        }

        public static async void TestConnection()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api-generator.retool.com/JbW1bY/employers");

            var response = await client.GetAsync(client.BaseAddress);
            Console.WriteLine(response.StatusCode);
        }
    }
}
