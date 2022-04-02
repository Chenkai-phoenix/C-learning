using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8_1
{
    public class Person : IFlyable
    {
        public virtual void FlyAble()
        {
            Console.WriteLine("人类在飞。。。");
        }
    }

    public class Female : Person, IFlyable
    {
        public override void FlyAble()
        {
            Console.WriteLine("男人在飞。。。");
        }
    }
    public class Male : Person, IFlyable
    {
        public override void FlyAble()
        {
            Console.WriteLine("女人在飞。。。");
        }

    }
    public class Simon : IFlyable, IsuperMan
    {
        void IFlyable.FlyAble()                 //接口方法显示实现，不可以加修饰符
        {
            Console.WriteLine("人妖在飞。。。");
        }
        void IsuperMan.FlyAble()
        {
            Console.WriteLine("超人妖在飞。。。");
        }
    }
}
