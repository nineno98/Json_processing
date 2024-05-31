using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace Write_json_obj_betoltes_nelkul
{
    class Log
    {
        private DateTime _date;
        private string _message;
        private string _level;

        public Log(DateTime date, string message, string level)
        {
            Date = date;
            Message = message;
            Level = level;
        }

        public DateTime Date { get => _date; set => _date = value; }
        public string Message { get => _message; set => _message = value; }
        public string Level { get => _level; set => _level = value; }

        public override string ToString()
        {
            return Message;
        }
    }

    internal class Program
    {
        static string jsonResult;
        static void Main(string[] args)
        {

            

            betoltes();
            
            Log ujLog = logCreate();
            string jsonItem = JsonConvert.SerializeObject(ujLog);
            Console.WriteLine(ujLog);
            hozzaad(jsonItem);
            //hozzaad(jsonItem);
            


            Console.ReadKey();

        }

        private static void betoltes()
        {
            if (File.Exists("result.json"))
            {
                Console.WriteLine("megvan");
                jsonResult = File.ReadAllText("result.json");
                Console.WriteLine(jsonResult);
            }
            else
            {
                jsonResult = "[]";
            }
        }

        private static void hozzaad(string jsonItem)
        {
            //string jsonResult = "[]";
            int lastIndex = jsonResult.IndexOf(']');
            StringBuilder sb = new StringBuilder();
            if (lastIndex > 2)
            {
                sb.Append(',');
            }
            
            sb.Append(jsonItem);
            
            jsonResult =  jsonResult.Insert(lastIndex, sb.ToString());
            Console.WriteLine("res"+ jsonResult);
            File.WriteAllText("result.json", jsonResult, Encoding.UTF8);
        }

        static public Log logCreate()
        {
            Console.WriteLine("Add meg naplóbejegyzés üzenetét.");
            string message = beker();
            Console.WriteLine("Add meg a naplóbejegyzés szintjét!");
            string level = beker();
            Log resLog = new Log(DateTime.Now, message, level);
            return resLog;
        }
        static public string beker()
        {
            string res = "";
            while (true)
            {
                res = Console.ReadLine();
                if (res != "")
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("A bevitel nem lehet üres.");
                }
            }
        }
    }
}
