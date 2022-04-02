using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo8
{
    public class Chinese : Person
    {
        public Chinese() { }
        public Chinese(string name,int age) : base(name,age)
        { }
        //子类重写虚类重名方法
        public override void SayHi()
        {
            Console.WriteLine("我叫{0}，年芳{1}，我是龙子", this.Name, this.Age);
        }
    }
    public class Japanese : Person
    {
        public Japanese() { }
        public Japanese(string name, int age) : base(name, age)
        { }
        //子类重写虚类重名方法
        public override void SayHi()
        {
            Console.WriteLine("我叫{0}，年芳{1}，我是柜子", this.Name, this.Age);
        }
    }
    public class Korean : Person
    {
        public Korean() { }
        public Korean(string name, int age) : base(name, age)
        { }
        //子类重写虚类重名方法
        public override void SayHi()
        {
            Console.WriteLine("我叫{0}，年芳{1}，我是棒子", this.Name, this.Age);
        }
    }
}
