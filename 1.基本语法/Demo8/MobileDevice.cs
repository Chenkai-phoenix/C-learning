using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    //移动存储设备（父类）
    public abstract class MobileDevice
    {
        public abstract void Read();
        public abstract void Write();
    }
}
