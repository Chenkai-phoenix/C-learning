using System;
using System.Collections.Generic;
using System.Linq;
/*----LINQ之常用扩展方法（1）
*1.大部分是IEnumerable<T>接口的扩展方法，因此继承了IEnumerable<T>接口的类都可以用LINQ的方法，数组，集合等等。
*2.where():条件判断  有满足条件的元素，返回元素类型的IEnumerable集合
*3.count()：条件计数 有满足条件的元素计数加1，返回计数总和    int
*4.Any（）：至少一个元素满足条件，返回true   bool
*5.Single(): 返回满足条件的唯一元素，多余一个或者是0都会异常。
*6.SingleOrDefault（）:返回满足条件的唯一元素,多余一个会异常，0个返回元素类型默认值，int返回0，string返回null
*7.First（）：满足条件的第一个元素,返回元素类型;都没有异常
*8.FirstOrDefault():满足条件的第一个元素,返回元素类型;都没有返回元素类型默认值
*9.Order（）：输出升序排列,不影响原始数据排列；返回类型IOrderedEnumerable<T> 
*10.OrderByDescending（）：输出降序排列，不影响原始数据排列；返回类型IOrderedEnumerable<T> 
*11.ThenBy():用在Order，OrderByDescending之后，表示按规则一排序后在按规则二升序排序
*12.Skip（）和Take（）：限制结果集，获取部分数据,
*一起用时：Skip()数据起始位置，Take（）获取个数
*独立用时：Skip()跳过数据数，Take（）获取个数，当数据个数少于取得数据会返会当前数据
*/
namespace ConsoleApp4
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

            IEnumerable<Employee> p1 = list.Where(i => i.Age > 30);  //Where（）
            Console.WriteLine("where() 方法结果是:");
            foreach (var item in p1)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Count() 方法结果是:");
            Console.WriteLine(list.Count(i => i.Gender == true));  //Count（）

            Console.WriteLine("Any() 方法结果是:");
            Console.WriteLine(list.Any(i => i.Salary >= 8000 && i.Gender == false));  //Any（）

            //Console.WriteLine("Single() 方法结果是:");
            //Employee sp1 = list.Single(i=>i.Name == "zack"); //Single（）
            //Console.WriteLine(sp1.ToString());

            Console.WriteLine("SingleOrDefault() 方法结果是:");  
            Employee sp2 = list.SingleOrDefault(i => i.Name == "1111"); //SingleOrDefault()
            if (sp2 == null)
            {
                Console.WriteLine("SingleOrDefault() 方法结果是：null");
            }
            else
            { 
                Console.WriteLine(sp2.ToString()); 
            }

            Console.WriteLine("First() 方法结果是:");    //First()
            Employee fp1 = list.First(i => i.Salary == 8000);
            Console.WriteLine(fp1.ToString());

            Console.WriteLine("OrderBy()方法结果是:");    //OrderBy()
            IOrderedEnumerable<Employee>  orderbylist = list.OrderBy(i => i.Age);
            foreach (var item in orderbylist)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("OrderByDescending()方法结果是:");    //OrderByDescending()和ThenBy（）
            IOrderedEnumerable<Employee> orderbyDesclist = list.OrderByDescending(i => i.Age).ThenBy(i=>i.Salary);
            foreach (var item in orderbyDesclist)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Skip()和Take（）方法结果是:");    //Skip()和Take（）
            var partiallist = list.Skip(2).Take(4);
            foreach (var item in partiallist)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
