using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo6
{
    internal class Teacher : Person
    {
        private int _salary;
        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        //无参构造
        public Teacher() { }
        //：base（参数列表）显示引用父类有参构造
        public Teacher(string name,int age,char gender,int salary):base(name,age,gender)
        {
            this.Salary = salary;
        }
        public void WorkKinds()
        {
            Console.WriteLine("教书");
        }
    }
}
