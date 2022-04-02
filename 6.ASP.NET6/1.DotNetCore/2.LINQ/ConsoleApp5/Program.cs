using System;
using System.Collections.Generic;
using System.Linq;
/*----LINQ之常用扩展方法（2）
 * 1.聚合函数：Min()；Max（）；Sum（）；Average（）；GroupBy()分组
 * 2.；GroupBy()分组:理解如何访问
 * 3.投影：.select();只取满足条件的元素
 * 4.匿名类型： var 变量名 = new{字段赋值} ;
 * 5.IEumerable<T>转换成数组类型或者集合类型
 * T[] array = XXX.ToArray();
 * List<T> list = XXX.ToList();
*/

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            list.Add(new Employee() { Id = 1, Name = "jerry", Age = 28, Gender = true, Salary = 5000 });
            list.Add(new Employee() { Id = 2, Name = "jim", Age = 38, Gender = true, Salary = 3000 });
            list.Add(new Employee() { Id = 3, Name = "lily", Age = 24, Gender = false, Salary = 9000 });
            list.Add(new Employee() { Id = 4, Name = "lucy", Age = 38, Gender = false, Salary = 2000 });
            list.Add(new Employee() { Id = 5, Name = "kimi", Age = 26, Gender = true, Salary = 1000 });
            list.Add(new Employee() { Id = 6, Name = "nancy", Age = 38, Gender = false, Salary = 8000 });
            list.Add(new Employee() { Id = 7, Name = "zack", Age = 48, Gender = true, Salary = 8500 });
            list.Add(new Employee() { Id = 8, Name = "jack", Age = 22, Gender = true, Salary = 8000 });

            int maxSalary = list.Where(i => i.Age > 30).Max(i => i.Salary);
            Console.WriteLine("年龄大于30的最大工资是{0}", maxSalary);
            //GroupBy()分组
            IEnumerable<IGrouping<int, Employee>> grouplsit = list.GroupBy(i => i.Age);
            foreach (IGrouping<int, Employee> item in grouplsit)
            {
                Console.WriteLine(item.Key);    //item.Key组名
                Console.WriteLine($"最高工资是{item.Max(i => i.Salary)}");
                foreach (Employee g in item)
                {
                    Console.WriteLine(g);        //g组员
                }
            }
            //.select();
            IEnumerable<int> age1 = list.Select(e => e.Age);
            IEnumerable<string> item1 = list.Where(i => i.Age > 35).Select(e => e.Name + "," + e.Age);
            foreach (string item in item1)
            {
                Console.WriteLine(item);
            }
            //匿名类型
            var dog = new { dogname = "beibei", dogage = 5 };
            Console.WriteLine($"匿名类型：{dog.dogname},{dog.dogage}");
            //投影加匿名使用
            var item2 = list.Select(e => new { xingming = e.Name, xingbie = e.Gender ? "男" : "女", nianling = e.Age });
            foreach (var item in item2)
            {
                Console.WriteLine($"匿名加投影：{item.xingming},{item.xingbie},{item.nianling}");
            }
            //案例：按年龄分组，输出每组的最高工资，最低工资，人数；匿名+分组+投影
            var item3 = list.GroupBy(e => e.Age).Select(g => new
            {
                GroupAge = g.Key,
                MaxSalary = g.Max(e => e.Salary),
                Minsalary = g.Min(e => e.Salary),
                PNum = g.Count()
            });
            Console.WriteLine("案例(按年龄分组，输出每组的最高工资，最低工资，人数；匿名 + 分组 + 投影):");
            foreach (var item in item3)
            {
                Console.WriteLine($"{item.GroupAge},{item.MaxSalary},{item.Minsalary},{item.PNum}");
            }
        }
    }
}