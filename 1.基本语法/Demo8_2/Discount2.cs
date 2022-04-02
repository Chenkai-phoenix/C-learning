using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    //打折子类2，按照，满m元减n元，
    public class Discount2 : BaseDiscount
    {
        public int M
        {
            get;
            set;
        }
        public int N
        {
            get;
            set;
        }
        //构造函数
        public Discount2(int m, int n)
        {
            this.M = m;
            this.N = n;
        }

        public override double RealMoney(double money)
        {
            double realmoney = 0;
            if (money >= this.M)
            {
                realmoney = money - (int)(money / this.M) * this.N; // 有几个M打折几个N
                Console.WriteLine("打折方式2：满{0}减{1}实际共消费{2}元。", this.M, this.N, realmoney);
                return realmoney;
            }
            else
            {
                realmoney = money;
                Console.WriteLine("打折方式2不满足条件，实际共消费{0}元。", realmoney);
                return realmoney;
            }
        }
    }
}
