using System;
using System.IO;
using System.Text;
/*----文件相关操作
*/
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Path相关
            string pathname = Path.GetFileName(@"1.txt");
            Console.WriteLine(pathname);
            string path1 = Path.GetFullPath(@"1.txt");
            Console.WriteLine(path1);
            string directoryname = Path.GetDirectoryName(path1);
            Console.WriteLine(directoryname);
            string extension = Path.GetExtension(path1);
            Console.WriteLine(extension);
            //File相关
            string str1 = "123123123";
            //File.WriteAllText(path1, str1);
            File.AppendAllText(path1, str1);
            byte[] buffer1 = new byte[1024];
            buffer1 = Encoding.Default.GetBytes("你好你好！");
            File.WriteAllBytes(path1,buffer1);
            //File.Delete(path1);
            //FileStream相关
            string path2 = @"2.txt";
            //using (FileStream fs1 = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.Write))
            //{
            //    string str2 = "我是filestream";
            //    byte[] buffer2 = new byte[1024];
            //    buffer2 = Encoding.Default.GetBytes(str2);
            //    fs1.Write(buffer2);
            //}
            using (FileStream fs2 = new FileStream(path2,FileMode.Open,FileAccess.Read))
            {
                byte[] buffer3 = new byte[1024];
                fs2.Read(buffer3);
                string str3 = Encoding.Default.GetString(buffer3);
                Console.WriteLine(str3);
                string fs2path = fs2.Name;
                Console.WriteLine(fs2path);
            }
            //Directory相关
            Directory.CreateDirectory("directory");
            string[] allDirectorys = Directory.GetDirectories(@"directory");
            string[] allFiles = Directory.GetFiles(@"directory");
            foreach (string item in allDirectorys)
            {
                Console.WriteLine(item);
            }
            foreach (string item in allFiles)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
