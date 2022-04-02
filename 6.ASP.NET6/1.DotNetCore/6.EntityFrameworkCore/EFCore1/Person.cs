using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    //搭建实体类（对象表）
    public class Person
    {
        public long Id { get; set; }
        public int Age { get; set; }
        public string Name{ get; set; }
        public string Gender { get; set; }
    }
}
