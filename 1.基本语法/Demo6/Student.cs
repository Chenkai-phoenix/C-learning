using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo6
{
    internal class Student : Person
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        //无参构造
        public Student() { }
        //：base（参数列表）显示引用父类有参构造
        public Student(string name, int age, char gender, int id) : base(name, age, gender)
        {
            this.Id = id;
        }

        public void WorkKind()
        {
            Console.WriteLine("学习");
        }
    }
}
