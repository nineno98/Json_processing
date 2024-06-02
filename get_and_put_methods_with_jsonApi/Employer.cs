using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace get_and_put_methods_with_jsonApi
{
    internal class Employer
    {   
        
        private string _name;
        private int _salary;

        
        private int _id;

        
        public Employer(string name, int salary)
        {
            _name = name;
            _salary = salary;
        }
        [JsonConstructor]
        public Employer(int id, string name, int salary)
        {
            _id = id;
            _name = name;
            _salary = salary;
        }



        
        public string Name { get => _name; set => _name = value; }
        public int Salary { get => _salary; set => _salary = value; }

        [JsonIgnore]
        public int Id { get => _id; set => _id = value; }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, salary: {Salary}";
        }
    }
}
