/*****************************************第六天******************************************/
/*----多肽
 * 1.基本概念：一个类型表现多种类型；使用父类表现子类
 * 2.实现多肽方法：
 * （1）虚方法：将父类中的方法标记为虚方法，使用关键字 virtual，
 *             子类中重写父类的虚函数，使用关键字override；
 *      
 *      使用时机：父类的需要实例化
 * （2）抽象类（不能实例化自己对象，可以子类对象赋值）：
 *     a.当父类中的方法不知道如何实现的时候，将父类协作抽象类，其方法为抽象方法；关键字abstract 
 *     抽象方法：
 *     a.无方法体即无{}(有{}不是无方法体，是空实现)；
 *     b.子类继承抽象类时必须重写抽象方法；使用关键字override
 *     d.与虚方法异同：
 *     同：子类重写父类方法都用关键字override
 *     异：1>虚方法可以实现可以空实现必须有方法体，抽象方法必须无方法体
 *        2>虚方法子类可以重写可以不重写，抽象方法子类必须重写抽象类中的所有抽象成员（属性，方法）；
 *     抽象属性：get；set；不能有方法体,子类中必须重写属性，使用关键字override；
 *     e.抽象类中可以有非抽象成员，但是非抽象类中不能有抽象成员
 *     f.若子类也是抽象类，则不需要重写父类的抽象成员
 *     使用时机：父类的不需要实例化，有抽象成员（不实现的成员）
 *3.多肽案例：用多肽来实现移动硬盘或者U盘或者MP3插到电脑进行读写数据；
 */
using System.IO;
using System.Text;
namespace Demo8
{
    class Program
    {
        static void Main(string[] args)
        {
            //虚方法
            Person p1 = new Person();
            Chinese long1 = new Chinese("陈凯", 29);
            Japanese gui1 = new Japanese("小仓", 28);
            Korean bang1 = new Korean("moon", 35);
            Person[] person1 = new Person[4] { p1, long1, gui1, bang1 };
            Console.WriteLine("------虚方法");
            foreach (Person item in person1)
            {
                item.SayHi(); //注意：item是父类类型，使用虚函数访问子类方法
            }
            Console.WriteLine();

            //抽象类和抽象方法
            Console.WriteLine("------抽象类和抽象方法");
            Animals dog1 = new Dog();//子类对象赋值实例化，但是本类不可以实例化 Animals dog1 = new Animals(); 错误
            Animals cat1 = new Cat();
            dog1.Bark();
            cat1.Bark();
            Console.WriteLine();

            //多肽案例：用多肽来实现移动硬盘或者U盘或者MP3插到电脑进行读写数据；
            Console.WriteLine("多肽案例：用多肽来实现移动硬盘或者U盘或者MP3插到电脑进行读写数据；");
            MobileDevice md1 = new MobileHardDisk();
            Computer cpu1 = new Computer();
            cpu1.Md = md1;         //精髓：将设备类型对象给到cpu的属性
            cpu1.CPURead();
            cpu1.CPUWrite();

            MobileDevice md2 = new UDisk();
            cpu1.Md = md2;
            cpu1.CPURead();
            cpu1.CPUWrite();

            MobileDevice md3 = new Mp3();     
            cpu1.Md = md3;
            cpu1.CPURead();
            cpu1.CPUWrite();
            ((Mp3) md3).PlayMusic();
            Console.WriteLine();


            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
