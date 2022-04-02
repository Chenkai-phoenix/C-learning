/*----异步方法
 */
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SyncDemo1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string filename1 = @"1.txt";
            Console.WriteLine("文件写入、读取的同步方法");
            File.WriteAllText(filename1, "hello1");
            string str1 = File.ReadAllText(filename1);
            Console.WriteLine(str1);

            Console.WriteLine("文件写入、读取的异步方法");
            string filename2 = @"2.txt";
            await File.WriteAllTextAsync(filename2, "hello2"); //异步传染性导致main也会变成异步方法
            string str2 = await File.ReadAllTextAsync(filename2);
            Console.WriteLine(str2);
            ////不加await可能出现的报错
            //string filename3 = @"3.txt";
            //StringBuilder stringBu = new StringBuilder(); //可变字符字符串
            //for(int i = 0;i<10000;i++)
            //{
            //    stringBu.Append("hello3");
            //}
            //File.WriteAllTextAsync(filename3, stringBu.ToString());
            ////报错：' because it is being used by another process.”
            ////原因：File.WriteAllTextAsync（）没有执行完，在其他线程占用filename3,
            ////因此  File.ReadAllTextAsync()无法读取，filename3。
            //string str3 =  await File.ReadAllTextAsync(filename3); 
            //Console.WriteLine(str3);
            Console.ReadKey();
        }
    }
}
