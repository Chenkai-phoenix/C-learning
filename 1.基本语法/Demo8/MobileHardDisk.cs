using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    public class MobileHardDisk:MobileDevice
    {
        public override void Read()
        {
            Console.WriteLine("MobileHardDisk Reading data.");
        }
        public override void Write()
        {
            Console.WriteLine("MobileHardDisk Writing data.");
        }
    }
}
