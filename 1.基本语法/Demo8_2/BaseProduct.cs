using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_2
{
    public class BaseProduct
    {
        public double Price    //自动属性；执行时会自动添加私有的字段；不需要对value加判断时使用；
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Id  //使用GUID
        {
            get;
            set;
        }
        //无参构造
        public BaseProduct() { }
        //有参构造
        public BaseProduct(string id,double price, string name)
        {
            this.Id = id;
            this.Price = price;
            this.Name = name;
        }
        
    }
}
