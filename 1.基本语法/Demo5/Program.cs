// See https://aka.ms/new-console-template for more information
/*----面向对象----*/
/*****************************************第一天******************************************/
/*基础概念：属性即特征，方法即行为；类是对象的类型
 * 1.语法：
 * (1):创建类
 * [public] class 类名
 *       {
 *          字段(field)； //变量
 *          属性(property)； //变量的限制
 *          方法(method)； //行为
 *       }
 *（2）new：1>实例化对象  类名 对象名 = new 类名（）；
 *         2>作用：开辟一块内存；创建对象；对象初始化（即执行构造函数）
 *（3）：this：1>指代当前类的对象；
 *            2>调用本类的重载构造函数；：this（）；
 *2.特点：类不占内存，对象占内存
 *3.结构体与类的异同：
 *（1）含义不同；
 *（2）封装，继承，多肽，结构体都不可用；
 *（3）语法相似；
 *4.属性: 变量的限制,用get{}，set{}方法来限制字段；属性本身不存值
 *5.一般字段的访问权限受保护，通过属性来访问和赋值字段
 *6.静态类与实例类（非静态类）
 *（1）在非静态类中：1>既可以有静态方法又可以有非静态方法（实例方法）；
 *                 2>对象可以点直接调用非静态成员（实例成员），不可以点调用静态成员；
 *                 3>用类名点调用静态成员
 *                 4>静态方法仅能访问静态成员
 *                 5>实例方法既可以使用静态成员又可以使用实例成员
 *                 注意：成员包括：方法，字段，属性
 *（2）在静态类中：1>静态类中仅能写静态成员（static方法，static字段，static属性），不能写实例成员；
 *               2>静态类不能实例化（对象不能调用静态成员） 
 *7.使用环境：(1)"工具类"一般用静态类；
 *           (2)静态类在整个项目中资源共享；（类不占内存，对象占内存；静态类占内存，存放在静态存储区域，且仅程序完全结束才释放资源）
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Demo5
{
    class Program
    {
        static void Main(string[] args )
        {
            //Person类,学习对象的初始化
            Person liuJian = new Person();//类的实例化即创建对象；这一步相当于声明和要内存；等效于Person liuJian；liuJian　new Person();
            liuJian.Name = "刘剑";
            liuJian.Age = -30;　　　//属性通过set { } 来限制赋值的有效性
            //liuJian.Age = 30;
            liuJian.Gender = '春';　//属性通过ｇet { } 来限制赋值的有效性
            liuJian.ShowInit();
            //Student类，学习构造函数（用来对象的初始化）
            Student stu1 = new Student();  //无参构造
            Student stu2=new Student("LL",28,'女',100,98,99);    //有参构造
            stu2.SayHello();
            stu2.ScoresPrint();
            //this调用类内函数；
            Student stu3 = new Student("SS", 27, '女',88);
            stu3.SayHello();
            stu3.ScoresPrint();

            /*****************************************第二天******************************************/
            /*----命名空间
             * 使用Using 命名空间;
            */
            /*----值类型与引用类型
             * 区别：
             * （1）内存中存储的位置不一样；值类型存储在栈内存，引用类型的值存储在堆内存中，地址存放在栈中；
             * 引用类型：string， class，数组；其余均值类型
             * （2）传递方式不一样；（分值传递，引用传递）          * 
             */
            /*----字符串
             * 1.相同的字符串值仅在堆中开辟一次内存
             * string st1 = "LL";
             * string st2 = "LL";    //&st1 == &st2,调试---窗口---即时
             * 2.string可以看做一个只读的char[],可以用下标读取单个字符，但是不可以写入；
             * string str3 = "asd"; 
             * console.write(str3[0]); //a
             * 3.改变字符串的某个字符:
             * (1)将字符串先变成字符数组；char[] chs = str.ToCharArray();
             * (2)将改变后的char[]转变为字符串， str = new string（chs）；
             * 4.StringBuilder类:做大量字符操作时候使用比string节省大量时间，返回结果用对象.tosting返回字符串类型；
             *   StringBuilder sb = new StringBuilder(); 
             *   sb大量字符串操作; 
             *   string sbRes = sb.ToString();
             * 5.Stopwatch类，即时器
             * Stopwatch sw = new Stopwatch();
             * sw.start();
             * sw.stop();
             * 6.字符串方法：
             * （1）str1.length；    //返回字符串字符个数，返回int类型
             * （2）str1.Equals(str2)；     //字符串比较,返回BOOL类型
             *  (3)str1.Split(char[] arry);     //字符串分割（剔除）,返回string[]
             * （4）str1.Substr(int startindex，int length);    //截取字符串，参数（截取起始位置，截取字符长度），返回string类型；
             * （5）str1.replace(str2,str3);   //将str1中的str2替换成str3；返回string类型
             * （6）str1.contains（str2）；    //判断str1中是否包含str2,返回bool类型
             * （7）str1.indexof(str2，int n);   //从n位置开始搜索str2在str1第一次出现的位置，返回int类型
             * （8）str1.trim（）；  //去除str1前后空格，返回string类型；
             */
            string str1 = "a s d 1 2 3 q w e";
            char[] arry1 = { '1', '2', '3', ' ', };
            //字符串分割,将str1中的arry1的字符截掉,StringSplitOptions.RemoveEmptyEntries 表示去除null值
            string[] strArry1 = str1.Split(arry1,StringSplitOptions.RemoveEmptyEntries);
           



            Console.ReadKey();
        }
    }

}