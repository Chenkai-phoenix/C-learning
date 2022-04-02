using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    public class Samsung:BaseProduct
    {
        //调用父类构造
        public Samsung(string id, double price, string name) : base(id, price, name)
        { }
    }
}
