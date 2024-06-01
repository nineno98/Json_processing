using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace get_and_put_methods_with_jsonApi
{
    internal class Employer
    {
        private int _id;
        private string _name;
        private int _salary;

        public Employer(int id, string name, int salary)
        {
            _id = id;
            _name = name;
            _salary = salary;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Salary { get => _salary; set => _salary = value; }

        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, salary: {Salary}";
        }
    }
}
