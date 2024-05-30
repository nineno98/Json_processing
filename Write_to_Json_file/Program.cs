using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using Newtonsoft.Json.Linq;


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
            listafeltolt();            
            menubetolt();       
            
            
            
            Console.ReadKey();
        }

        private static void listafeltolt()
        {
            StreamReader sr = new StreamReader("result.json");
            var json = sr.ReadToEnd();
            var jsonArr = JArray.Parse(json);
            foreach (var item in jsonArr)
            {
                Felhasznalo felhasznalo = new Felhasznalo(
                    item["Id"].Value<int>(),
                    item["Name"].Value<string>(),
                    item["Email"].Value<string>()                   
                    );
                felhasznalok.Add( felhasznalo );
            }
            
            sr.Close();

        }

        private static void menubetolt()
        {
            do
            {
                Console.WriteLine("Új felhasználó: 1 |Felhasználók lista: 2 | Kilépés: 3");
                string valaszt = Console.ReadLine();
                if (valaszt.Equals("1"))
                {
                    hozzafuz();
                }
                else if (valaszt.Equals("2"))
                {
                    foreach (var item in felhasznalok)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (valaszt.Equals("3"))
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Csak a megadott számok közzül válassz.");
                }
            } while (true);
        }

        private static void hozzafuz()
        {
            Felhasznalo ujfelhasznalo = ujFelhasznalo(felhasznalok.Select(x => x.Id).Max()+1);
            felhasznalok.Add(ujfelhasznalo);

            string json = JsonConvert.SerializeObject(felhasznalok);
            File.WriteAllText("result.json", json);
            
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
