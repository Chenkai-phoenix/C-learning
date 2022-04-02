using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketClient
{
    internal class VIVO : Products
    {
        public VIVO(string guid, double singlePrice) : base(guid, singlePrice)
        {
            this.Name = "VIVO";
        }
    }
}
