using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;

namespace json_process_from_jsonfile
{
    internal class Program
    {
        static List<Megrendeles> megrendelesek = new List<Megrendeles> ();
        static void Main(string[] args)
        {
            megrendelesek = beolvasas();
            Console.ReadKey();
        }

        private static List<Megrendeles> beolvasas()
        {
            List<Megrendeles> res = new List<Megrendeles>();
            StreamReader reader = new StreamReader("megrendelesek.json");
            var json = reader.ReadToEnd();
            var jsonArr = JArray.Parse(json);

            foreach (var item in jsonArr)
            {
                
            }
            Console.WriteLine(jsonArr[0]);
            return res;
        }
    }
}
