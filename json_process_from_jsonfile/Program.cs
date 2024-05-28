using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
            return res;
        }
    }
}
