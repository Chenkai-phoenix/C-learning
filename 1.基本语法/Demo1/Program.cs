// See https://aka.ms/new-console-template for more information
namespace _Demo1
{
    class program
    {
        static void Main(string[] args)
        {

            /********************第一天**********************/
            decimal m = 1.5E6m;
            Console.WriteLine(m);  // output: 1500000
            float ff = 3_000.5F;
            Console.WriteLine(ff); // output: 3000.5

            /* 控制台I/O
             * Console.ReadLine() 返回类型为string.
             */
            Console.WriteLine("input name and age ");
            string name;
            name = Console.ReadLine();
            string age;
            age = Console.ReadLine();
            Console.WriteLine(name);
            // 占位符
            Console.WriteLine("name is {0},age is {1}", name, age);
            /*@字符作用
             * (1):取消'\'的转义字符功能
             * (2):保持原格式输出
            */

            Console.WriteLine("F:\\黑灯瞎火\\富士山下\\仓井老师.avi");
            Console.WriteLine(@"F:\屌丝天堂\东京又不热\波多老师.avi");

            Console.WriteLine(@"曾经沧海难为水，
除去巫山不是云。");
            Console.WriteLine(@"取次花丛懒回顾，
            半缘修道半缘君。");
            //精度表示
            Console.WriteLine("有效数字");
            double num1 = 3.333333333;
            Console.WriteLine("两位有效数字：{0:0.00}", num1);
            /********************第二天**********************/
            /*类型不兼容的类型强转
             * Convert.to
             * 条件：
             */
            //将string转换为double
            string str1 = "1234";
            double num2 = Convert.ToDouble(str1);
            int num3 = Convert.ToInt32(str1);
            Console.WriteLine("string to double {0}", num2);
            Console.WriteLine("string to int32 {0}", num3);
            /*自加自减 ++,--
             */
            int num4 = 10;
            int num5 = ++num4;
            num4 = 10;
            int num6 = num4++;
            Console.WriteLine("自加{0}", num4); // 11
            Console.WriteLine("前加{0}", num5); // 11
            Console.WriteLine("后加{0}", num6); // 10
            /*判断闰年
             * 条件：（1）能被400整除
             *       (2）能被4整除但不能被100整除
             *       （year % 400 == 0 ）|| （years % 4 == 0 && years % 100 ！= 0）
             */
            /********************第三天**********************/
            /*异常捕获
             * 解释：语法没有错，但是由于某些原因程序无法正常运行
             * 用法：有需要时再用，try-catch之间不允许有其他代码；
             * 语法：
             *      try
             *      {
             *          可能出现异常的代码语句；
             *      }
             *      catch
             *      {
             *          出现异常后执行的代码；
             *      
             *      }
             */
            Console.WriteLine("input a num!");
            int num7 = 0;
            bool excaption1 = false;//用bool表示是否进入异常
            try
            {
                num7 = Convert.ToInt32(Console.ReadLine());  //若此行代码出现异常则之后代码均不执行
                                                             //   Console.WriteLine("num * 2 is {0}", num7 * 2); //try中不推荐写与异常无关语句
            }
            catch
            {
                excaption1 = true;//有异常
                Console.WriteLine("input erro num!!");
            }
            if (excaption1 == false)
            {
                Console.WriteLine("num * 2 is {0}", num7 * 2);
            }
            /*字符串类型转数字类型
             *   Convert.ToInt32()本质调用了 int.Parse();
            */
            int num8 = int.Parse("123");
            int num9 = 0;
            bool b1 = int.TryParse("123", out num9);    //若可以转换，b1返回TRUE,num9值为123；
                                                        //bool b1 = int.TryParse("123asd", out num9);    //若不可以转换，b1返回FALSE,num9值为原值；
            Console.WriteLine(num8);
            Console.WriteLine(num9);
            Console.WriteLine(b1);
        }

    }
}