/*****************************************第七天******************************************/
/*----访问修饰符
 * 一.种类：
            1.public:都可以访问（包括别的项目）
              //（1）先鼠标右键添加项目引用，（2）然后添加命名空间；
            2.private：仅类内可以类外不行
            3.protected：类内及子类内可以
            4.internal：当前程序集中访问（当前项目内），在同一个项目中  与 public权限一样
            5.protect internal
   二.仅能修饰类的：public，internal

*-----简单工厂设计模式
* 一.设计模式：设计项目的一种方式；二十三种设计模式
* 二.案例：根据用户输入的品牌生产电脑；（Lenovo，IBM,Acer,Dell）
* 
* -----序列化与反序列化
* 一.概念
* 1.序列化：将对象转换为二进制；
*   反序列化：将二进制转换为对象；
* 2.作用：传输数据。 
* 3.将类标记为可序列化：
* (1)类上方[Serializable]
* (2) 使用二进制格式类：将对象转换为二进制
*               BinaryFormatter bf1 = new BinaryFormatter();
                bf1.Serialize(fWrite1, person1);
 （3）反序列化：Person person2 = (Person)bf2.Deserialize(fRead1);

-----部分类
1.概念：同一个命名空间下同名类：关键字 partial class 类名；（所有同名类都必须加partial）本质就是一个类，只是在不同的地方写；
2.作用：同时对一个类进行操作；

-----密封类
1.概念：关键字sealed class 类名；
2.特点：密封类不能被继承，但可以继承别人；


 */
using System.Runtime.Serialization.Formatters.Binary;

namespace Demo9
{
    class Program
    {
        static void Main(string[] args)
        {
            //*-----简单工厂设计模式之案例
            //输入电脑品牌
            Console.WriteLine("input pad brand!");
            string padBrand = Console.ReadLine();
            Factory pad1 = GetPad(padBrand);  //pad1一个类型表现多个类型
            if (pad1 != null)
            {
                pad1.CreatPad();    //利用多态访问子类成员
            }
            Console.WriteLine();

            //-----序列化与反序列化
            Person person1 = new Person();
            person1.Name = "小泽";
            person1.Age = 20;
            person1.Id = 10086;
            //模拟对象序列化
            using (FileStream fWrite1 = new FileStream("序列化.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf1 = new BinaryFormatter();
                bf1.Serialize(fWrite1, person1);
            }
            Console.WriteLine("序列化成功！");
            //模拟对象反序列化
            using (FileStream fRead1 = new FileStream("序列化.txt",FileMode.Open,FileAccess.Read))
            {
                BinaryFormatter bf2 = new BinaryFormatter();
                Person person2 = (Person)bf2.Deserialize(fRead1);
                Console.WriteLine("反序列结果是{0}，{1}，{2}。", person2.Name, person2.Age, person2.Id);
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.ReadKey();
        }

        public static Factory GetPad(string brand)  //工厂模式核心：子类对象赋值给父类
        {
            Factory gb = null;
            switch (brand)
            {
                case "Lenovo":
                    gb = new Lenono();             //工厂造电脑
                    break;
                case "IBM":
                    gb = new Ibm();
                    break;
                case "Acer":
                    gb = new Acer();
                    break;
                case "Dell":
                    gb = new Dell();
                    break;
                default:
                    Console.WriteLine("input erro!");
                    break;
            }
            return gb;                           //返回子类对象填充的父类对象
        }
    }

    public abstract class Factory   //父类工厂
    {
        public abstract void CreatPad();
    }

    public class Lenono : Factory    //子类1 lenovo
    {
        public override void CreatPad()
        {
            Console.WriteLine("Lenovo pad is created!");
        }
    }

    public class Ibm : Factory      //子类2 IBM
    {
        public override void CreatPad()
        {
            Console.WriteLine("IBM pad is created!");
        }
    }

    public class Acer : Factory     //子类3 acer
    {
        public override void CreatPad()
        {
            Console.WriteLine("Acer pad is created!");
        }
    }

    public class Dell : Factory     //子类4 Dell
    {
        public override void CreatPad()
        {
            Console.WriteLine("Dell pad is created!");
        }
    }
  


}