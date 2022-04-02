/*****************************************第三天******************************************/
/*----继承
 * (1)语法：【public】 class 子类（派生类）：父类（基类）
 * (2)使用条件：将共同的通项抽象成一个父类（基类），仅保留各自特点的类为子类（派生类）；
 * (3)继承的特点：
 * 1>单根性：子类只能有一个父类；
 * 2>传递性：类的内容可以向下传递
 *（4）继承的内容：
 *1>子类继承父类的属性和方法
 *2>父类允许访问的内容，父类私有不能继承(子类可以访问父类public，protected);
 *3>子类不继承父类的构造函数,但是子类实例对象时会运行父类的无参构造，因此父类若有构造重载时，必须要在父类中补充被干掉的无参构造；
 *4>子类显示调用父类的构造函数（重载），：base（参数列表）;//重要
 *本质：子类实例对象时会先实例化父类无参对象；
 * (5)C#中所有类的第一基类是object类；
 *（6）new关键字：当子类和父类中有重名的方法时，new子类对象时会自动隐藏父类继承的重名成员，因此不会访问到父类的重名成员；//重要
 */
/*----里氏转换
 * （1）子类可以赋值给父类；作用：当需要父类对象做参数时可以给一个子类对象代替
 * 
 * （2）如果父类中装的子类对象，则该父类可以强转为子类
 *  (3)对象转换关键字：is，as
 *  类1对象名 is 类2名：如果可以转换，返回true，否则返回false；
 *  类2对象名 as 类2名：如果可以转换，返回类2对象，否则返回null；
 *----访问修饰符
 *（1）public：类内类外均可访问    
 *（2）private：仅类内可以访问，类外不可以访问
 *（3）protected：仅类内和子类内可以访问，类外不可以访问
 */
/*****************************************第四天******************************************/
/*----集合
 * 1.ArrayList al = new ArrayList[]；
 * （1）非静态类；
 * （2）多种数据类型的数据集合
 *  (3)命名空间：using System.Collections;
 * （4）其成员均是object类型，因此可以里氏转换；
 * （5）al.add(object value)：添加元素，索引从0开始
 * （6）al.addRange(object value)：添加集合或者数组；不用if判断数组，不用for循环输出，
 * （7）al.clear();清空所有元素
 * （8）al.Remove(object v);删除单个元素，删谁写谁
 * （9）al.RemoveAt(object v)；按下标索引删除
 *（10）al.RemoveRange(startpos，length)；根据下标算出length个元素
 *（11）al.Reverse（）；反转
 *（12）al.Insert(pos,value);在指定位置插入单个元素
 *（13）al.InsertRange(pos,value[]);在指定位置插入集合
 *（14）al.Contains（value）；判断是否包含value，返回ture或者false
 *（15）al.Count；集合实际的元素个数
 *（16）al.Capacity；集合可以包含的元素个数（本质：al申请的内存大小）
 *ArrayList集合的优缺点：优点：可以存放不同类型值，缺点：元素都是object类，因此赋值给其他类型都需强制转换；
 *
 * ----哈希表（键值对集合）
 * Hashtable:
 * (1)添加：hashtable1.Add(object key，object value);
 *（2）循环访问hashtable：foreach（var item in collection）{}
 *  推断类型var:根据值推断值的类型（数据类型）；缺陷：使用的时候必须初始化
 *  item:集合的项（数组的元素，切记不是索引）
 *  collection：集合名（可以是集合，数组）
 *（3）哈希表key必须是唯一的，值可以重复；即第一个参数key不能重复，第二个参数value可以变
 *（4）hashtable1.ContainKey(object key);查询是否包含某键，包含返回true，不包含返回false
 *（5）hashtable1.ContainValue(object value);查询是否包含某值；包含返回true，不包含返回false
 *（6）清空哈希表：hashtable1.Clear();
 * (7)根据键删除：hashtable1.Remove(object key);
 * 
 * ----List泛型集合（对照ArryList）
 * 优点：确定输出元素的类型，和访问类型；
 * 1.语法：List<int> list1 = new List<int>();
 * 2.常用方法：与ArrayList差不多
 * 3.集合初始化器：List<string> list2 = new List<string>() { "a","b","c","d"};    
 * 
 * ----装箱和拆箱
 * 1.基本概念：
 * (1)装箱：将值类型转换为引用类型
 * (2)拆箱：将引用类型转换为值类型
 * 一般来说要避免装箱和拆箱；当循环多时，装箱拆箱会严重耗时
 * 2.条件：两种类型必须有继承关系
 * 
 * ----Dictionary字典集合（对照Hashtable）
 * 1.语法：Dictionary<TYPE, TYPE> diction1 = new Dictionary<TYPE, TYPE>();
 *  例如： Dictionary<int, string> diction1 = new Dictionary<int, string>();
 * 2.与Hashtable比，确定了key和value的类型
 * 3.遍历:kv可以访问键，也可以访问值
 * foreach (KeyValuePair<int,string> kv in dict1)
            {
                Console.WriteLine("key is {0},value is {1}",kv.Key,kv.Value);
            }
 */
using System.Collections;
using System.Diagnostics;

namespace Demo6
{
    class Program
    {
        static char[] simplifiedChinese = { '1', '2', '3', '4', '5', '6' };    //简体中文
        static char[] traditionalChinese = { '一', '二', '三', '四', '五', '六' };      //繁体

        static void Main(string[] args)
        {
            //继承
            Student stud1 = new Student();
            Student stud2 = new Student("ck", 23, '男', 1001001);
            Teacher teacher1 = new Teacher("ll", 33, '女', 18000);
            //里氏转换

            Person person1 = new Student();

            /*子类可以赋值给父类，此时父类装子类对象；
             * 等效于：Student stud3 = new Student();Person person1 = stud3;
             */

            Student stud4 = (Student)person1;       //若父类装子类对象，则可以强转为子类；

            //对象转换关键字is和as
            if (person1 is Student)     //is 如果可以转换，返回true，否则返回false；
            {
                Student stud5 = (Student)person1;
            }
            else
            {
                Console.WriteLine("转换失败");
            }

            Teacher teacher2 = person1 as Teacher;  //as 如果可以转换，返回对象，否则返回null；

            string[] strArry1 = new string[] { "1", "2", "3", "4" };
            string str1 = string.Join("|", strArry1); //Join(Char, Object[]);Object是一切类的基类，string子类赋值给基类
            Console.WriteLine(str1);
            //创建ArrayList集合
            ArrayList arrayList1 = new ArrayList();
            arrayList1.Add(1);
            arrayList1.Add(3.14);
            arrayList1.Add(true);
            arrayList1.Add("张三");
            arrayList1.Add('a');
            arrayList1.Add(new int[] { 1, 2, 3, 4, 5, 6 }); //不可以直接访问到数组元素，会返回数组所在命名空间，System.Int32[]
            Person person2 = new Person();
            arrayList1.Add(person2);                  //不可以直接访问对象成员，会返回对象的类所在的命名空间 Demo6.Person
            arrayList1.AddRange(new int[] { 7, 8, 9, 10, 11, 12 });  //添加数组；不用if判断数组，不用for循环输出，
            arrayList1.AddRange(arrayList1);                 //添加集合；
            for (int i = 0; i < arrayList1.Count; i++)
            {

                if (arrayList1[i] is Person)
                {
                    //里氏转换，arrayList1.Add(object），因此arrayList1[i]是object对象，object是一切类父类，所以可以强转子类对象
                    Person person3 = (Person)arrayList1[i];

                    Console.WriteLine("集合中Person的方法是:");
                    person3.CHLSS();
                }
                else if (arrayList1[i] is int[])
                {
                    //里氏转换，arrayList1.Add(object），因此arrayList1[i]是object对象，object是一切类父类，所以可以强转子类对象
                    int[] arry1 = (int[])arrayList1[i];
                    for (int j = 0; j < arry1.Length; j++)
                    {
                        Console.WriteLine("集合的内容有：{0}", arry1[j]);
                    }
                }
                else
                    Console.WriteLine("集合的内容有：{0}", arrayList1[i]);

            }
            Console.WriteLine();

            //创建哈希表Hashtable
            Hashtable hashtable1 = new Hashtable();
            hashtable1.Add(1, "张三");
            hashtable1.Add(2, 123);
            hashtable1.Add(3, 'a');
            hashtable1.Add(true, 1);
            hashtable1[4] = "A"; //也通过赋值添加数据
            //通过key找值
            Console.WriteLine("Hashtable key true的值是{0},", hashtable1[true]);
            //通过循环访问hashtable，foreach（var item in collection）
            foreach (var item in hashtable1.Keys)   //item此时是hashtable1.Keys数组的元素
            {
                Console.WriteLine("Hashtable1 key is {0},value is {1}", item, hashtable1[item]);
            }
            //foreach()循环访问数组；
            int[] arry2 = { 12, 13, 14, 15, 16 };
            foreach (var item in arry2)         //item此时是数组arry2的各个元素
            {
                Console.WriteLine("arry2 is {0}", item);
            }
            Hashtable hashtable2 = hashtable1;
            hashtable2.Remove(true); //删除true及值；
            hashtable2.Clear();
            //Hashtable案例，简繁转换
            Hashtable chineseTrans = new Hashtable();
            for (int i = 0; i < simplifiedChinese.Length; i++)
            {
                chineseTrans.Add(simplifiedChinese[i], traditionalChinese[i]);
            }
            char inputKey1 = '5';
            char valueRes;
            SimpTransTrad(chineseTrans, inputKey1, out valueRes);
            Console.WriteLine("繁体字是{0}", valueRes);
            Console.WriteLine();

            //----List泛型集合
            List<int> list1 = new List<int>();
            List<string> list2 = new List<string>() { "a", "b", "c", "d" };     //集合初始化器
            list1.Add(1);
            list1.AddRange(new int[] { 9, 8, 7, 6 });           //new int[] { 9, 8, 7, 6 } 数组初始化器
            Console.WriteLine("List<int>集合结果是：");

            foreach (int item in list1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("List<string>集合结果是：");
            foreach (string item in list2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //----装箱和拆箱
            ArrayList arrylist2 = new ArrayList();
            List<int> list3 = new List<int>();
            Stopwatch sw1 = new Stopwatch(); //计时器
            Stopwatch sw2 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < 10000000; i++)
            {
                arrylist2.Add(i);  //装箱：int给object赋值；
            }
            sw1.Stop();
            Console.WriteLine("arrylist2.Add(i)用时{0}", sw1.Elapsed);  //sw1.Elapsed:用时
            Console.WriteLine();

            sw2.Start();
            for (int i = 0; i < 10000000; i++)
            {
                list3.Add(i);  //int 给 int
            }
            sw2.Stop();
            Console.WriteLine("List<int> list3.Add(i)用时{0}", sw2.Elapsed); //sw2.Elapsed远小于sw1.Elapsed
            Console.WriteLine("当循环次数很多时List<int>类型时间远小于ArrayList类型,原因是ArrayList一直装箱拆箱");
            Console.WriteLine();

            //----Dictionary字典集合（对照Hashtable）
            Dictionary<int, string> dict1 = new Dictionary<int, string>();
            dict1.Add(1, "小泽");
            dict1.Add(2, "吉泽");
            dict1.Add(3, "樱井");
            dict1.Add(4, "波多");
            dict1.Add(5, "龙泽");
            foreach (KeyValuePair<int,string> kv in dict1)
            {
                Console.WriteLine("key is {0},value is {1}",kv.Key,kv.Value);
            }

            Console.WriteLine();
            Console.ReadKey();
        }
        static void SimpTransTrad(Hashtable hashtable, object key, out char value)
        {
            value = (char)hashtable[key];
        }
    }
}
