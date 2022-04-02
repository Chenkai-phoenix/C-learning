using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    public  class Cat : Animals
    {
        public override string KindName
        {
            get { return _kindName; }
            set { _kindName = value; }
        }
        public override void Bark()
        {
            Console.WriteLine("Cat喵喵喵。。。");
        }
    }
}
