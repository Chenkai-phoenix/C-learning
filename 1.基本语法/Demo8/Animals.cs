using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    //抽象类
    public abstract class Animals
    {
        public string _kindName;
        //抽象属性;
        public abstract string KindName
        {
            get;
            set;
        }

        //抽象方法
        public abstract void Bark();
    }
}
