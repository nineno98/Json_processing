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
            foreach (var item in megrendelesek)
            {
                Console.WriteLine(item);
            }
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
                Dolgozo dolgozo = new Dolgozo(
                    item["dolgozo"]["username"].Value<string>(),
                    item["dolgozo"]["first_name"].Value<string>(),
                    item["dolgozo"]["last_name"].Value<string>()
                    );
                Alapanyag alapanyag = new Alapanyag(
                    item["alapanyag"]["id"].Value<int>(),
                    item["alapanyag"]["anyagtipusa"].Value<string>(),
                    item["alapanyag"]["vastagsag_valaszt"].Value<double>(),
                    item["alapanyag"]["meret_valaszt"].Value<string>(),
                    item["alapanyag"]["darabszam"].Value<int>(),
                    item["alapanyag"]["polc_szama"].Value<int>(),
                    item["alapanyag"]["rogzit_datum"].Value<DateTime>()
                    );
                Megrendeles megrendeles = new Megrendeles(
                    item["id"].Value<int>(),
                    dolgozo,
                    item["munkalap_szama"].Value<string>(),
                    alapanyag,
                    item["datumKezdes"].Value<DateTime>(),
                    item["datumBefejezes"].Value<DateTime>(),
                    item["felhasznaltMennyiseg"].Value<int>()
                    );
                
                res.Add(megrendeles);
            }
            
            return res;
        }
    }
}
