using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo9
{
    [Serializable]
    public class Person
    {
        private string _name;
        private int _age;
        private int _id;

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

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
