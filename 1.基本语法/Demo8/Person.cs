using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    public class Person
    {
        private string _name;
        private int _age;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Person() { }
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        //父类虚方法
        public virtual void SayHi()
        {
            Console.WriteLine("我是Person！,我是父类");
        }
    }
}
