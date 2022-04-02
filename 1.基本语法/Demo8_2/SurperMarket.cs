using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    public class SuperMarket
    {
        //创建仓库对象；
        Warehouse cangku1 = new Warehouse();
        //构造函数
        public SuperMarket()
        {
            //仓库进货，本质给仓库初始化 （name，count）
            cangku1.Purchase("Acer", 600);
            cangku1.Purchase("Samsung", 700);
            cangku1.Purchase("Banana", 800);
            cangku1.Purchase("Soy", 1000);
        }

        //与用户买卖交互方法
        public void AskBuying()
        {
            Console.WriteLine("欢迎光临，请问需要什么？");
            Console.WriteLine("我们超市有：Acer{0}台，Samsung{1}台，Banana{2}斤，Soy{3}瓶.", cangku1.list[0].Count, cangku1.list[1].Count, cangku1.list[2].Count, cangku1.list[3].Count);
            string strType = Console.ReadLine();        //用户要的产品类型
            Console.WriteLine("请问需要{0}的数量是多少？", strType);
            int productsCount1 = Convert.ToInt32(Console.ReadLine());   //用户要的产品数量

            //取货
            BaseProduct[] buyProducts1 = cangku1.PickProducts(strType, productsCount1);  //用户买的所有产品对象

            //结账
            double allMoney = GetMoney(buyProducts1);

            //折扣和促销方式：1.按打折率；2.满M元减N元
            Console.WriteLine("输入1：按打折率0.8打折；*******输入2：满M元减N元；******请选择！");
            int discountkinds = Convert.ToInt32(Console.ReadLine());

            BaseDiscount bd1 = GetBD(discountkinds);    //简单工厂，用switch使用子类对象给父类赋值；
            double realMoney = bd1.RealMoney(allMoney);
            //用户所买商品信息汇总
            BuyInfos(buyProducts1);
        }

        //收款方法
        public double GetMoney(BaseProduct[] buyProducts)
        {
            //收款总金额
            double allMoney = 0;
            double realMoney = 0;
            foreach (var item in buyProducts)
            {
                allMoney += item.Price;
            }
            Console.WriteLine("您全场总共消费{0}元。", allMoney);
            return allMoney;
        }
        //根据用户选择 折扣和促销方式：1.按打折率；2.满M元减N元
        public BaseDiscount GetBD(int n)
        {
            BaseDiscount bd = null;
            switch (n)
            {
                case 1:
                    double dr = 0.8;    //1.按打折率0.6
                    bd = new Discount1(dr);
                    break;
                case 2:
                    int MMM = 500;     //2.满M元减N元
                    int NNN = 100;
                    bd = new Discount2(MMM, NNN);
                    break;
            }

            return bd;
        }

        //用户购买产品信息汇总
        public void BuyInfos(BaseProduct[] buyProducts)
        {
            foreach(var item in buyProducts)
            {
                Console.WriteLine("购买的产品是{0}, ID是{1}, 单价是{2}。",item.Name,item.Id,item.Price);
            }
        }


        //显示货物
        public void ShowProducts()
        {
            cangku1.ShowProducts();
        }

    }
}
