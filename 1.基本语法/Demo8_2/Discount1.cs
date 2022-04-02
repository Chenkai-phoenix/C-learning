using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    //打折子类1，按打折率打折
    public class Discount1 : BaseDiscount
    {
        public double DR     //打折率：DiscoutRate
        {
            get;
            set;
        }

        //构造函数

        public Discount1(double dr)    //获得打折率
        {
            this.DR = dr;
        }
        public override double RealMoney(double money) //打折后实际费用
        {
            double realmoney = this.DR * money;
            Console.WriteLine("打折方式1：打折率{0}实际共消费{1}元。",this.DR, realmoney);
            return realmoney;
        }
    }
}
