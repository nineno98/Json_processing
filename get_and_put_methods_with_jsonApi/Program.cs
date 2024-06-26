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

        public static HttpClient client;
        static void Main(string[] args)
        {
            ClientSetUp();
            // GET:

            // kapcsolat tesztelése
            //TestConnection();

            // összes dolgozó
            LoadEmployers();

            //egy dolgozó név alapján
            //var customEmployer = GetCustomEmployer("Erhart Harken");

            //pagination első 10 rekord
            //LoadEmployersLimited(10);
            //ListOfEmloyers();

            // POST:
            //Add employer
            //AddNewEmployer();

            //delete employer
            //DeleteEmployerFromID(53);

            // PUT: update employer datas
           // modifierEmployer(Employers.First());

            // PATCH:
            // update property field name:
            modifierNameOfEmployer(Employers.First());
            //ListOfEmloyers();







            Console.ReadKey();
        }

        private static async void modifierNameOfEmployer(Employer employer)
        {
            string appurl = $"employers/{employer.Id}";
            Console.WriteLine("A változtatni kívánt dolgozó adatai: "+employer);
            Console.WriteLine("Add meg az új nevet:");
            string name = bekeres();
            var json = "{\"Name\":\""+name+"\"}";
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), appurl)
                {
                    Content = content

                };
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success."+response.Content.ToString());
                }
                else
                {
                    Console.WriteLine("Error."+response.Content);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("modifierNameOfEmployer: "+e.Message);
            }
            
        }

        

        public static HttpContent CreateHttpContent(Employer employer)
        {
            var json = JsonConvert.SerializeObject(employer);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }

        private static async void modifierEmployer(Employer employer)
        {
            string appuri = $"employers/{employer.Id}";
            Console.WriteLine("A változtatni kívánt dolgozó adatai: "+employer+"\nÚj adatok megadása");
            Employer ModifieredEmployer = CreateNewEmployer();
            try
            {
                HttpContent content = CreateHttpContent(ModifieredEmployer);
                
                var response = await client.PutAsync(appuri, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success.");
                }
                else
                {
                    Console.WriteLine("Error.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("modifierEmployer: "+e);
            }
  
        }

        private static async void DeleteEmployerFromID(int id)
        {
            try
            {

                Employer selectedEmp = Employers.SingleOrDefault(x => x.Id == id);
                if (selectedEmp != null)
                {
                    string apiurl = $"employers/{selectedEmp.Id}";
                    var response = await client.DeleteAsync(apiurl);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                else
                {
                    Console.WriteLine("Employer not found.");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("DeleteEmployerFromID: "+e.Message);

            }
            

        }

        
       

        private static void AddNewEmployer()
        {
            try
            {
                string apiurl = "employers";
                LoadEmployers();
                Employer newEmployer = CreateNewEmployer();
                HttpContent content = CreateHttpContent(newEmployer);
                
                var request = client.PostAsync(apiurl, content);
                LoadEmployers();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }

        private static Employer CreateNewEmployer()
        {
            Console.WriteLine("Add meg a nevet:");
            string nev = bekeres();
            Console.WriteLine("Add meg a fizetését:");
            int salary = int.Parse(bekeres());
            
            
            Employer res = new Employer(nev, salary);
            return res;

        }

        private static string bekeres()
        {
            string input = "";
            while (true)
            {
                input = Console.ReadLine();
                if (input != "" )
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Meg kell adni értéket.");
                }
            }
        }

        private static void ListOfEmloyers()
        {
            foreach (var item in Employers)
            {
                Console.WriteLine(item);
            }
        }

        private static void ClientSetUp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api-generator.retool.com/JbW1bY/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static async void LoadEmployersLimited(int numberOfEmployers)
        {
            try
            {
                string appurl = $"employers?_page=1&_limit={numberOfEmployers}";
                var response = client.GetAsync(appurl).Result;
                var jsonResponse = await response.Content.ReadAsStringAsync();

                ProcessJsonString(jsonResponse);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public static async Task<Employer> GetCustomEmployer(string name)
        {
            Employer customEmployer = null;
            try
            {     
                string application = $"employers?name={name}";              
                var response = client.GetAsync(application).Result;                
                var json = JArray.Parse( await response.Content.ReadAsStringAsync());
                if (json.Count() != 0)
                {
                    customEmployer = JsonConvert.DeserializeObject<Employer>(json[0].ToString());
                    
                    return customEmployer;
                }
                else
                {
                    return customEmployer;
                }
               
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return customEmployer;
            }
        }

        public static async void LoadEmployers()
        {
            try
            {
                string appurl = "employers";
                

                var response = client.GetAsync(appurl).Result;
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
            Employers.Clear();
            var jsonArray = JArray.Parse(jsonstring);
            foreach (var item in jsonArray)
            {
                Employer emp = JsonConvert.DeserializeObject<Employer>(item.ToString());
                Employers.Add(emp);
            }
        }

        public static async void TestConnection()
        {           
            var response = await client.GetAsync(client.BaseAddress);
            Console.WriteLine(response.StatusCode);
        }
    }
}
