using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    public class Mp3:MobileDevice
    {
        public override void Read()
        {
            Console.WriteLine("Mp3 Reading data.");
        }
        public override void Write()
        {
            Console.WriteLine("Mp3 Writing data.");
        }
        public void PlayMusic()
        {
            Console.WriteLine("Mp3 playing music.");
        }
    }
}
