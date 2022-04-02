using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketClient
{
     class Iphone: Products
    {
        public Iphone( string guid, double singlePrice) : base( guid, singlePrice)
        {
            this.Name = "Iphone";
        }
    }
}
