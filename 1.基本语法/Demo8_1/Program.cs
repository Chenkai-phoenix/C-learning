/*----接口
 * 1.概念：接口就是一个规范,能力（功能）；
 * 2.关键字：interface I接口名able;
 * 3.接口作用：一个类需要继承多个类时，使用接口；（类继承的单根性只能继承一个类）
 * 4.特点：
 * （1）接口中的成员不允许添加访问修饰符；（默认public）
 * （2）接口不允许定义成员（字段，属性，方法），即可以声明方法但是无方法体；
 * （3）类继承接口时必须实现接口的所有成员(可以重写，可以普通实现，即加不加override)；
 *  (4)接口只能继承接口不能继承类；类既可以继承类也可以继承接口；
 * （5）当一个类继承一个类和多个接口时，语法必须把父类现在最前面，接口现在后面；
 * 
 * 5.显示使用接口:解决不同接口的方法重名问题，不可以加修饰符；
 * 例如：void IFlyable.FlyAble() {...}
 * 
 * 6.接口的本质就是一个规范的功能壳（模子）；
 */
namespace Demo8_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            IFlyable IFly1 = new Female();
            IFlyable IFly2 = new Male();
            IFly1.FlyAble();    //实现接口方法
            IFly2.FlyAble();
            Console.WriteLine();

            Person P1 = new Female();
            Person P2 = new Male();
            P1.FlyAble();       //重写父类虚方法
            P2.FlyAble();
            Console.WriteLine();

            //显示实现接口方法,处理继承不同接口时方法重名问题
            IFlyable IFly3 = new Simon();
            IsuperMan IFly4 = new Simon();
            IFly3.FlyAble();
            IFly4.FlyAble();
            Console.WriteLine();

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
