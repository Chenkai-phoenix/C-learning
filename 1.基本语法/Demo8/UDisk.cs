using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    public class UDisk:MobileDevice
    {
        public override void Read()
        {
            Console.WriteLine("UDisk Reading data.");
        }
        public override void Write()
        {
            Console.WriteLine("UDisk Writing data.");
        }
    }
}
