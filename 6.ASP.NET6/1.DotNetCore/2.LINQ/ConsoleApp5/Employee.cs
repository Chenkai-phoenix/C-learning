using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; } //ture:男；false：女
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"ID = {Id},Name = {Name},Age = {Age},Gender = {Gender},Salary = {Salary}";
        }

    }

}
