using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    public class Computer
    {
        private MobileDevice _md;
        public MobileDevice Md
        {
            get { return _md; }
            set { _md = value; }
        }
        public void CPURead()
        {
            Md.Read();

        }
        public void CPUWrite()
        {
            Md.Write();
        }
    }
}
