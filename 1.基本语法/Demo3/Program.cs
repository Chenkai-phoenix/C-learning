// See https://aka.ms/new-console-template for more information
namespace _Demo3
{
    public class Program
    {
        //使用静态字段模拟全局变量作用
        public static int _number = 10; //作用域为lass Program,C#没有全局变量，

        static void Main(string[] args)
        {
            /********************第五天**********************/
            /*----方法（函数）
             * 调用：类名.方法（）(当方法与Main方法同类时可以省略类名)；
             * 高级参数：out，ref,params
             */
            int maxValue1 = Program.GetMaxValue(4, 44);
            int maxValue2 = GetMaxValue(2, 22);
            Console.WriteLine("maxValue1 is {0}", maxValue1);
            Console.WriteLine("maxValue2 is {0}", maxValue2);
            Console.WriteLine("_number is {0}", _number);
            //求一个数组中的最大值，最小值，总和，平均值
            int[] arry1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //1.方法返回多个相同类型值可以用数组类型返回。本质：方法的返回值为数组类型
            int[] arry2 = new int[4];
            arry2 = GetMaxMinSumAvg(arry1);
            Console.WriteLine("最大值是{0}，最小值是{1}，总和是{2}，平均值是{3}", arry2[0], arry2[1], arry2[2], arry2[3]);

            //2.out使用:方法返回多个不同类型值，。本质：通过方法的形参带出返回值
            int maxOut = 0;
            int minOut = 0;
            string sumOut = "0";
            string avgOut = "0";
            GetMaxMinSumAvgOut(arry1, out maxOut, out minOut, out sumOut, out avgOut);
            Console.WriteLine("最大值是{0}，最小值是{1}，总和是{2}，平均值是{3}", maxOut, minOut, sumOut, avgOut);

            //ref使用:将一个变量带入void方法，在方法内操作后又将改变后的变量带出;
            //ref的值在方法外必须初始化
            int num1 = 20;
            SelfAdd(ref num1);
            Console.WriteLine("ref 使用结果是{0}", num1);

            //params（可变参数）使用：params修饰数组形参时候，传参时可以传数组元素，代替传数组；
            /*注意：（1）需要注意传入元素的数据类型
             *     （2）params修饰的形参必须是形参列表最后一个参数
             *     （3）一个方法最多仅有一个params修饰的参数
             * 优势：任意改变数组的长度/元素个数，不需要重新声明一个新数组
             */
            string name1 = "chenkai";
            int[] score1 = { 90, 92, 95, 97 };
            ParamsTest(name1, score1);  //ParamsTest(string name, params int[] score)，params修饰数组形参既可以传数组
            ParamsTest("ll", 13, 53, 76, 33, 55, 66, 77); //params修饰数组形参又可以直接传数组元素
            /********************第六天**********************/
         /*
          * ----方法的重载(与c语言一致):方法名，返回值类型相同，参数列表不同，
          */
         
        }
        //求两个int型的最大值
        public static int GetMaxValue(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }
        //返回数组类型
        public static int[] GetMaxMinSumAvg(int[] arry)
        {
            int[] res1 = new int[4];
            res1[0] = arry.Max();
            res1[1] = arry.Min();
            res1[2] = arry.Sum();
            res1[3] = arry.Sum() / arry.Length;
            return res1;
        }
        //out使用
        public static void GetMaxMinSumAvgOut(int[] arry, out int max, out int min, out string sum, out string avg)
        {

            max = arry.Max();
            min = arry.Min();
            sum = Convert.ToString(arry.Sum());
            avg = Convert.ToString((arry.Sum() / arry.Length));
        }

        //ref使用，自加方法
        public static void SelfAdd(ref int num)
        {
            num++;
        }
        //params使用，
        public static void ParamsTest(string name, params int[] score)
        {
            int sum = 0;
            for (int i = 0; i < score.Length; i++)
            {
                sum = sum + score[i];
            }
            Console.WriteLine("{0}的学分总和是{1}", name, sum);
        }
    }
}
