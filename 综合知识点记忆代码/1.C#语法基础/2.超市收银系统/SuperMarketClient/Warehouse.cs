using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketClient
{
    class Warehouse
    {
        //仓库
        private static Dictionary<string, List<Products>> warehouse = new Dictionary<string, List<Products>>();
        private static List<List<Products>> buyerproducts = new List<List<Products>>();
        private static int iphoneInitCount = 100;
        private static int huaweiInitCount = 500;
        private static int vivoInitCount = 300;
        public Warehouse()
        {
            List<Products> iphones = new List<Products>();
            for (int i = 0; i < iphoneInitCount; i++)
            {
                iphones.Add(new Iphone(Guid.NewGuid().ToString(), 8888));
            }

            List<Products> huaweis = new List<Products>();
            for (int i = 0; i < huaweiInitCount; i++)
            {
                huaweis.Add(new HuaWei(Guid.NewGuid().ToString(), 6666));
            }

            List<Products> vivos = new List<Products>();
            for (int i = 0; i < vivoInitCount; i++)
            {
                vivos.Add(new VIVO(Guid.NewGuid().ToString(), 5888));
            }

            warehouse.Add("Iphone", iphones);
            warehouse.Add("HuaWei", huaweis);
            warehouse.Add("VIVO", vivos);

            buyerproducts.Add(new List<Products>());
            buyerproducts.Add(new List<Products>());
            buyerproducts.Add(new List<Products>());

        }

        public void WarehouseShow()
        {
            foreach (KeyValuePair<string, List<Products>> kv in warehouse)
            {
                Console.WriteLine("{0}目前存货是{1}", kv.Key, kv.Value.Count);
            }
        }
        public void GetProducts(string name, int count)
        {
            //从仓库取货
            switch (name)
            {
                case "Iphone":
                    for (int i = 0; i < count; i++)
                    {
                        buyerproducts[0].Add(new Iphone(warehouse["Iphone"][0].Guid, 8888));
                        warehouse["Iphone"].RemoveAt(0);


                    }
                    break;
                case "HuaWei":
                    for (int i = 0; i < count; i++)
                    {
                        buyerproducts[1].Add(new HuaWei(warehouse["HuaWei"][0].Guid, 6666));
                        warehouse["HuaWei"].RemoveAt(0);
                    }
                    break;
                case "VIVO":
                    for (int i = 0; i < count; i++)
                    {
                        buyerproducts[2].Add(new VIVO(warehouse["VIVO"][0].Guid, 5888));
                        warehouse["VIVO"].RemoveAt(0);
                    }
                    break;
                default:
                    break;
            }
        }
        public void BuyShow()
        {
            int count = buyerproducts.Count;
            double allprice = 0;
            allprice = buyerproducts[0].Count * 8888 + buyerproducts[1].Count * 6666 + buyerproducts[2].Count * 5888;
            Console.WriteLine("用户本次一共消费{0}元", allprice);
            Console.WriteLine("详情如下：");
            for (int i = 0; i < buyerproducts.Count; i++)
            {
                if (buyerproducts[i].Count > 0)
                {
                    
                    Console.WriteLine("{0}购买{1}个,单价{2}元,共{3}元。", buyerproducts[i][0].Name, buyerproducts[i].Count, buyerproducts[i][0].SinglePrice, buyerproducts[i].Count * buyerproducts[i][0].SinglePrice);
                }
            }


        }
    }
}
