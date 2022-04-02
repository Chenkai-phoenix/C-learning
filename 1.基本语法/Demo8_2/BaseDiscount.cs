using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    //打折，促销父类
    public abstract class BaseDiscount
    {
        public abstract double RealMoney(double money);
    }
}
