using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
/*---异步编程之Whenall
1.属于task类的方法
2.语法： Whenall<TRsult>(params Task<TResult>[] tasks),返回值类型Task<TResult[]>
3.作用：当多个task都完成，返回task；用于等待多个执行任务结束，但不要求所有任务的执行顺序。
4.task.FromResult（T）:创建普通数值的task对象,返回task<int>类型
案例：使用whenall，输入一个文件夹下所有文件的字符和？
*/
namespace SyncDemo5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task<string> task1 = File.ReadAllTextAsync(@"新建文件夹\1.txt"); //没有使用await，可以不执行完成就执行一下语句
            Task<string> task2 = File.ReadAllTextAsync(@"新建文件夹\2.txt");
            Task<string> task3 = File.ReadAllTextAsync(@"新建文件夹\3.txt");
            //whenall:所有任务都结束才返回
            string[] tasks = await Task.WhenAll(task1,task2,task3);//使用await，将返回值类型task<string[]> 转换为string[]

            string str1 = tasks[0];
            string str2 = tasks[1];
            string str3 = tasks[2];
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);

            int sum = await GetFilesChars(@"新建文件夹");
            Console.WriteLine(sum);
        }
        //案例：使用whenall，输入一个文件夹下所有文件的字符和？
        static async Task<int> GetFilesChars(string directoryname)
        {
            string[] files = Directory.GetFiles(directoryname);   //获取文件夹下所有文件路径
            Task<int>[] filelenTask = new Task<int>[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                string file1 = await File.ReadAllTextAsync(@files[i]);
                filelenTask[i] = Task.FromResult(file1.Length);   //int型转换为task<int>
            }
            int[] count = await Task.WhenAll(filelenTask);       
            int sum = count.Sum();      //命名空间linq

            return sum;      
        }
    }
}
