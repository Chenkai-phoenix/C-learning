using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo5
{
    public class Person
    {
        private string _name;    //字段受保护
        private int _age;
        private char _gender;
        public string Name      //属性：本质最后还是赋值给了字段，属性本身不存储值
        {

            get { return _name;}

            set { _name = value;}
        }
        public int Age
        {
            get { return _age; }
            set                             //属性通过set { } 来限制赋值的有效性
            {
                if (value <= 0)
                { _age = 0; }
                else
                { _age = value; }
            }
        }

        public char Gender
        {
            get                             //属性通过get { } 来限制赋值的有效性
            {   if (_gender != '男' && _gender != '女')
                { 
                    return _gender='＊';
                }
                return _gender;
            }
            set { _gender = value; }
        }

        public void ShowInit()  //方法
        {
            Console.WriteLine("name is {0}",this.Name);    //this：当前类的对象
            Console.WriteLine("age is {0}",this.Age);
            Console.WriteLine("gender is {0}",this.Gender);
        }

    }
}
