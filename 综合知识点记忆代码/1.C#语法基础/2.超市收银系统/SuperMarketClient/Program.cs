//----超市收银客户端

namespace SuperMarketClient
{
    class Progam
    {
        static void Main()
        {
            Warehouse wh = new Warehouse();
            wh.WarehouseShow();
            wh.GetProducts("HuaWei", 10);
            wh.GetProducts("Iphone", 20);
            wh.GetProducts("VIVO", 30);
            wh.BuyShow();
            wh.WarehouseShow();

        }
    }
}