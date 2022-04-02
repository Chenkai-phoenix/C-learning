using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    //仓库类
    public class Warehouse
    {
        //存储货物
        // List<BaseProduct> sanList = new List<BaseProduct>();  //放货物不清楚货物类型
        //创建货架
        public List<List<BaseProduct>> list = new List<List<BaseProduct>>();  //不加public对象无法访问集合

        //构造函数
        public Warehouse()
        {
            //生成货架实例
            list.Add(new List<BaseProduct>());  //list[0]表示Acer
            list.Add(new List<BaseProduct>());  //list[1]表示Samsung
            list.Add(new List<BaseProduct>());  //list[2]表示Banana
            list.Add(new List<BaseProduct>());  //list[3]表示Soy
          
        }

        //进货；不同的货架添加对应的货物对象
        public void Purchase(string strType, int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Acer":
                        list[0].Add(new Acer(Guid.NewGuid().ToString(), 1000, "Acer pad!")); //Acer货架添加Acer对象（guid，price，name）
                        break;
                    case "Samsung":
                        list[1].Add(new Samsung(Guid.NewGuid().ToString(), 2000, "Samsung pad!"));//Samsung货架添加Samsung对象
                        break;
                    case "Banana":
                        list[2].Add(new Banana(Guid.NewGuid().ToString(), 2, "Frash Banana !"));//Banana货架添加Banana对象
                        break;
                    case "Soy":
                        list[3].Add(new Soy(Guid.NewGuid().ToString(), 15, "Soy!"));//Soy货架添加Soy对象
                        break;
                    default:
                        break;
                }
            }
        }

        //取货
        public BaseProduct[] PickProducts(string strType, int count)
        {
            BaseProduct[] pickProducts1 = new BaseProduct[count];
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Acer":
                        if (list[0].Count != 0)
                        {
                            pickProducts1[i] = list[0][0];  //从货架取一个Acer对象
                            list[0].RemoveAt(0);            //从货架删除一个Acer对象,后面的一个Acer对象自动顶上； list[0] =list[1];
                        }
                        break;
                    case "Samsung":
                        if (list[1].Count != 0)
                        {
                            pickProducts1[i] = list[1][0];
                            list[1].RemoveAt(0);
                        }
                        break;
                    case "Banana":
                        if (list[2].Count != 0)
                        {
                            pickProducts1[i] = list[2][0];
                            list[2].RemoveAt(0);
                        }
                        break;
                    case "Soy":
                        if (list[3].Count != 0)
                        {
                            pickProducts1[i] = list[3][0];
                            list[3].RemoveAt(0);
                        }
                        break;
                }
            }


            return pickProducts1;
        }

        //仓库货物展示
        public void ShowProducts()
        {
            foreach (var item in list)
            {
                //item此时是货架集合，集合有数量，对象有名字，价格；
                if (item.Count > 0)
                {

                    Console.WriteLine("仓库的货物有：产品{0}，数量{1}，单价{2}", item[0].Name, item.Count, item[0].Price);
                    Console.WriteLine("---------------------------------");
                }
                else
                    Console.WriteLine("注意仓库中有货物为空！！");

            }
        }
    }
}
