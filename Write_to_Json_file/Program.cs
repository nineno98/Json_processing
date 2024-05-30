using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using System.ComponentModel.Design;


namespace Write_to_Json_file
{
    class Felhasznalo
    {
        private int _id;
        private string _name;
        private string _email;

        public Felhasznalo(int id, string name, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }

        public override string ToString()
        {
            return $"{Id}, {Name}, {Email}";
        }
    }
    
    internal class Program
    {
        static List<Felhasznalo> felhasznalok = new List<Felhasznalo>();
        static void Main(string[] args)
        {

            menubetolt();

            //string json = JsonConvert.SerializeObject(felhasznalok);
            //Console.WriteLine(json);
            //File.WriteAllText("result.json", json);
            string json = File.ReadAllText("result.json");
            
            
            Console.ReadKey();
        }

        private static void menubetolt()
        {
            do
            {
                Console.WriteLine("Új felhasználó: 1 |Felhasználók lista: 2| Kilépés: 3");
                string valaszt = Console.ReadLine();
                if (valaszt.Equals("1"))
                {
                    hozzafuz();
                }
            } while (true);
        }

        private static void hozzafuz()
        {
            Felhasznalo ujfelhasznalo = ujFelhasznalo(2);
            felhasznalok.Add(ujfelhasznalo);
            
        }

        static private List<Felhasznalo> feltolt()
        {
            List<Felhasznalo> felhasznList = new List<Felhasznalo>();
            int id = 1;
            do
            {
                Console.WriteLine("Új felhasználó: 1 | Kilépés: 2");
                string bevitel = Console.ReadLine();
                if (bevitel.Equals("1"))
                {                  
                    felhasznList.Add(ujFelhasznalo(id));
                    id++;
                }
                else
                {
                    break;
                }
                
            } while (true);
            return felhasznList;
        }

        static private Felhasznalo ujFelhasznalo(int id)
        {
            Console.WriteLine("Add meg a felhasználó nevét:");
            string nev = beker();
            Console.WriteLine("Add meg az emailcímet:");
            string email = beker();

            Felhasznalo felhasznalo = new Felhasznalo(id, nev, email);
            return felhasznalo;
        }
        static private string beker()
        {
            string res = "";
            do
            {
                res = Console.ReadLine();
                if (res != "")
                {
                    return res;
                }
                else
                {
                    Console.WriteLine("A bevitel nem lehet üres string.");
                }
            } while (true);
        }
    }
}
