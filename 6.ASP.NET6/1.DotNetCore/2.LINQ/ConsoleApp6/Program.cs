using System;
using System.Collections.Generic;
using System.Linq;
/*----LINQ之简单面试问题
 * 使用LINQ链式写法做算法；
*/

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //案例1
            string scoreStr = "107.5,168.5,196.5";
            double ResScore = ScoreAvrg(scoreStr);
            Console.WriteLine(ResScore);
            //自己写的字符串分割
            List<string> strs = SplitTest(scoreStr, ',');
            foreach (string item in strs)
            {
                Console.WriteLine(item);
            }
            //案例2
            string str1 = "Hellow,Nice to meet you .";
            StatisticsTest(str1);

        }
        //案例1：一个用逗号分割的成绩字符串，求成绩的平均值
        static double ScoreAvrg(string score)
        {
            string[] strs = score.Split(',');    //字符串分割
            IEnumerable<double> nums = strs.Select(e => Convert.ToDouble(e));
            double scoreAvrg = nums.Average();
            return scoreAvrg;
        }
        //自己写的字符串分割
        static List<string> SplitTest(string str, char n)
        {
            int strlen = str.Length;
            List<string> strs = new List<string>();

            int j = 0;
            for (int i = 0; i < strlen; i++)
            {
                string str1 = "";
                int k = 0;
                for (; j < strlen; j++)
                {
                    if (str[j] == n)
                    {
                        j++;
                        break;
                    }
                    str1 = str1 + str[j].ToString();
                    k++;
                }
                strs.Add(str1);
                if (j >= strlen)
                {
                    return strs;
                }
            }

            return strs;
        }
        //案例2：统计一个字符串中每个字母出现的频率（忽略大小写），然后从频率大到小输出频率大于2字母，及频率
        static void StatisticsTest(string str)
        {
            var items = str.Where(c => char.IsLetter(c)).Select(c => char.ToLower(c))
                           .GroupBy(c => c).Select(g => new { char1 = g.Key, count = g.Count() })
                           .Where(e => e.count > 2).OrderByDescending(e => e.count);
            var items1 = str.Where(c => char.IsLetter(c)).Select(c => char.ToLower(c))
                         .GroupBy(c => c).Select(g => new { char1 = g.Key, count = g.Count() })
                         .OrderByDescending(e => e.count);
            foreach (var item in items)
            {
                Console.WriteLine($"{item.char1},{item.count}");
            }
            Console.WriteLine($"---------------------------------------");
            foreach (var item in items1)
            {
                Console.WriteLine($"{item.char1},{item.count}");
            }
        }
    }
}
