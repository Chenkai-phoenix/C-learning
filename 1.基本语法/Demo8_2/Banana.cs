using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    public class Banana:BaseProduct
    {
        //调用父类构造
        public Banana(string id, double price, string name) : base(id, price, name)
        { }
    }
}
