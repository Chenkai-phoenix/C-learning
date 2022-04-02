using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketClient
{
     class Products
    {
        private string _name;
        private int _guid;
        private double _singlePrice;
        private int _count;
        public string Name
        {
            get;
            set;
        }
        public string Guid
        {
            get;
            set;
        }
        public double SinglePrice
        {
            get;
            set;
        }

        public Products() { }
        public Products(string guid,double singlePrice)
        {
            this.Guid = guid;
            this.SinglePrice = singlePrice;
        }
    }
}
