// See https://aka.ms/new-console-template for more information
namespace _Demo2
{
    /*
     * 枚举：
     * [public] enum 枚举名 (public可写可不写)
     * {
     *      值1，
     *      值2，
     *      ...
     * }
     */
    public enum ColorKinds
    {
        red,
        green,
        blue,
        yellow,
        ERROR
    }

    /*
    * 结构体：
    * [public] struct 结构名 (public可写可不写)
    * {
    *   成员变量；
    *   成员函数；
    * }
    */
    public struct Person
    {
        public string _name; //_区别成员变量(c#称作字段)和普通变量
        public int _age;
        public ColorKinds _colorPerson;
    }
    public class Program
    {
        static void Main(string[] args)
        {
        /********************第四天**********************/
            //----枚举使用
            ColorKinds color1 = ColorKinds.red;
            ColorKinds color2 = color1 + 1;
            Console.WriteLine(color1);
            Console.WriteLine(color2);

            /*枚举类型转换其他类型
             * （1）枚举类型与int类型兼容可以相互强转换（若输入的int是枚举中没有的值，则返回输入的int值）
             * 
             * （2）枚举类型与string类型转换（注意：所有类型都可以转换为string，color2.ToString();）
             */
            Console.WriteLine((int)color1);
            Console.WriteLine((int)color2);

            //枚举转string（任意类型均可以转string）
            string str1 = Convert.ToString(color1);
            string str2 = color2.ToString();
            Console.WriteLine("str1 is {0}", str1);
            Console.WriteLine("str2 is {0}", str2);

            //string转枚举 (枚举类型) Enum.Parse(typeof(枚举类型),string);
            //若转换不了则出现异常（例如，输入的字符串枚举中没有的值）
            string str3 = "3";
            ColorKinds color3 = (ColorKinds)Enum.Parse(typeof(ColorKinds), str3);
            Console.WriteLine("color3 is {0}", color3);

            //案例1：提示用户选择一个颜色，（0：red，1：gree，2：blue，3：yello）
            Console.WriteLine("输入一个数字（0：red，1：gree，2：blue，3：yello）：");
            string str4 = Console.ReadLine();
            ColorKinds inputColor;
            try
            {
                inputColor = (ColorKinds)Enum.Parse(typeof(ColorKinds), str4);
            }
            catch
            {
                inputColor = ColorKinds.ERROR;
            }
            switch (inputColor)
            {
                //case ColorKinds.red:
                //    Console.WriteLine("选择的颜色是：{0}", inputColor);
                //    break;
                //case ColorKinds.green:
                //    Console.WriteLine("选择的颜色是：{0}", inputColor);
                //    break;
                //case ColorKinds.blue:
                //    Console.WriteLine("选择的颜色是：{0}", inputColor);
                //    break;
                //case ColorKinds.yellow:
                //    Console.WriteLine("选择的颜色是：{0}", inputColor);
                //    break;
                //default:
                //    Console.WriteLine("颜色选择erro！");
                //    break;

                //case 条件：执行语句相同可以省略
                case ColorKinds.red:
                case ColorKinds.green:
                case ColorKinds.blue:
                case ColorKinds.yellow:
                    Console.WriteLine("选择的颜色是：{0}", inputColor);
                    break;
                default:
                    Console.WriteLine("颜色选择erro！");
                    break;
            }

            //----结构体使用
            Console.WriteLine("结构体使用。");
            Person person1;
            person1._name = "chenkai";
            person1._age = 23;
            person1._colorPerson = ColorKinds.red;
            Console.WriteLine("姓名是：{0}\n年龄是：{1}\n颜色是：{2}", person1._name, person1._age, person1._colorPerson);

            //----数组的使用
            int[] num1 = new int[10];   //c#整形数组声明及赋值,索引从0开始
            num1[0] = 10;
            int[] num2 = { 1, 2, 3, 4, 5 }; //数组声明方式2
            Console.WriteLine("num1[0] is {0}", num1[0]);

            Person[] person2 = new Person[10];  //结构体数组声明及赋值  
            person2[9]._name = "chenkai";
            person2[9]._age = 22;
            person2[9]._colorPerson = ColorKinds.blue;
            Console.WriteLine("person2[9]._name is {0}", person2[9]._name);
            Console.WriteLine("person2[9]._age is {0}", person2[9]._age);
            Console.WriteLine("person2[9]._colorPerson is {0}", person2[9]._colorPerson);

            Console.WriteLine("person2’s length is {0}", person2.Length);// person2.Length  数组长度
        }
    }
}