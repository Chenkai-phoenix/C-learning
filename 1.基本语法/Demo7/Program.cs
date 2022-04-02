/*****************************************第五天******************************************/
/*文件相关操作*/
/*----Path类
 * 1.概念：专门操作路径
 * 2.命名空间：using System.IO;
 * 3.静态类，不能声明对象
 * 4.绝对路径：全路径
 * 5.相对路径：存放在代码中的某个文件夹，代码中直接使用“文件名.扩展名”
 * 
 * ----File类
 * 1.概念：专门操作文件（只操作小文件）
 * 2.命名空间：using System.IO;
 * 3.静态类，不能声明对象
 * 4.文件读写：
 * 读：
 * （1）File.ReadAllBytes（），返回字节数组 byte[] 
 *         string str = Encoding.Default.GetString(buffer1) ;二进制编码转字符串，using System.Text;
 * （2）File.ReadAllLines(); 按行读取，返回字符串数组
 *  (3)File.ReadAllText(path4);按文本读取，返回字符串 
 * 写：
 * （1）File.WriteAllBytes(path5,buffer2); 按字节写入；buffer2 为 byte[] 类型
 * （2）File.WriteAllLines(path5,str5);按行写入；str5 为 string[] 类型
 * （3）File.WriteAllText(path5, str4);按字符串写入；str4为string类型
 * 以上写入均会覆盖之前的内容。
 *  (4)追加写入：File.AppendAllText(path5, "你被干掉了吗？") Text可以替换Bytes，Lines
 *  5.判断文件是否存在file.Exsits();
 *  6.删除文件：File.Delete();
 *  7.剪切文件：File.Move（）;

 * ----Directory类
 * 1.概念：专门操作文件夹
 * 2.常用方法：
 * (1)Directory.CreateDirectory(@"F:\CSharpCode\directory"+ count1); //可以使用循环创建文件夹
 * (2)Directory.Delete(@"F:\CSharpCode\directory2"); //删除文件夹
 *（3）bool b2 = Directory.Exists(@"F:\CSharpCode"); //判断文件夹是否存在
 *（4）Directory.Move(源路径，目标路径)；//移动文件夹，剪切
 *（5）string[] str6 = Directory.GetDirectories(@"F:\CSharpCode"); //返回路径中的所有文件夹的路径
 *（6）string[] str7 = Directory.GetFiles(@"F:\CSharpCode");//返回路径中的所有文件的路径
 *                     Directory.GetFiles(@"F:\CSharpCode","*.txt");//返回路径中的所有txt文件的路径
 *
 *----FileStream
 *1.概念：专门操作字节，可以操作一切文件
 *2.使用流程：
 *（1）//创建文件流读对象 FileStream fsRead1 = new FileStream(path4, FileMode.Open, FileAccess.Read); 
 *    //创建文件流写对象 FileStream fsRead1 = new FileStream(path4, FileMode.OpenOrCreat, FileAccess.Write); 
 *    //FileMode.OpenOrCreat:没有文件就创建文件，有就打开
 *（2）//创建缓冲区大小 byte[] buffer3 = new byte[fsRead1.Length]; //读小文件就设置流长度大小
 *（3）//读取 int realRead1 = fsRead1.Read(buffer3, 0, buffer3.Length);
 *     //第一个参数：缓冲区；第二个参数：偏移量，第三个参数：最多读取量；返回值：实际读取的数据
 *（4）//将字节数组转换为字符串 string str8 = Encoding.Default.GetString(buffer3);
 *（5）//关闭文件和释放资源 fsRead1.Close(); fsRead1.Dispose();
 *----Stream
 *1.概念：专门操作字符，操作大文件
 *2.流读取：StreamReader
 *（1）读取流：StreamReader sr1 = new StreamReader(fsRead2);
 *（2）读取文本文件路径：StreamReader sr1 = new StreamReader(path4，Encoding.Default);//Encoding.Defualt编码出现问题时添加
 * (3)访问StreamReader字符串： string str = sr1.readline（）；
 *3.流写入：StreamWriter
 *   与读取一样，将Reader改为Writer即可
 *   读写完必须关闭文件，.close();
  *4.使用using自动释放资源：using（）{}//不需要写***.close();***.Dispose();
 */
using System.IO;
using System.Text;

namespace Demo7
{
    class Program
    {
        static void Main(string[] args)
        {
            //path类的常用方法
            string path1 = @"C:\Users\dell\Pictures\壁纸\1.jpg";  //@取消转义字符的作用
            string fileName1 = Path.GetFileName(path1);      //获取路径中的文件名
            string fileName2 = Path.GetFileNameWithoutExtension(path1);     //获取路径中的文件名没有扩展名
            string extensionName1 = Path.GetExtension(path1);   //获取路径中的文件扩展名
            string directoryName1 = Path.GetDirectoryName(path1);    //获取路径中文件所在文件夹名
            string pathName = Path.GetFullPath(path1);      //获取文件全路径

            Console.WriteLine("filename is {0}", fileName1);
            Console.WriteLine("filename without extension is {0}", fileName2);
            Console.WriteLine("extension  is {0}", extensionName1);
            Console.WriteLine("directoryName1  is {0}", directoryName1);
            Console.WriteLine("pathName is {0}", pathName);

            Console.WriteLine("两个字符串合并后的路径是：{0}", Path.Combine(@"c:\小泽\", "热不热.avi")); //将两个字符串合并成路径

            //File类的常用方法
            string path2 = @"C:\Users\dell\Pictures\壁纸\100.jpg";
            string path3 = @"C:\Users\dell\Pictures\壁纸\101.jpg";
            string path4 = @"csharpRead.txt"; //相对路径F:\CSharpCode\Demo7\bin\Debug\net6.0
            //File.Create(path2);    //创建一个文件
            //File.Delete(path2);    //删除文件
            //File.Copy(path2, path3);    //将已有的文件复制,path2:源路径文件，path3：目标路径（必须要有文件名）
            //判断文件是否存在
            bool b1 = File.Exists(path2);
            Console.WriteLine("文件是否存在：{0}", b1);
            //文件剪切
            //File.Move(path2, @"C:\Users\dell\Pictures\100.jpg");

            //文件读
            byte[] buffer1 = File.ReadAllBytes(path4);          //（1）File.ReadAllBytes（）；按字节读取， 返回二进制字节型数组
            string str1 = Encoding.Default.GetString(buffer1);  //二进制编码为字符串
            Console.WriteLine("按字节读取并转换为字符串结果是：");
            Console.WriteLine(str1);
            Console.WriteLine();

            string[] str2 = File.ReadAllLines(path4);            //(2)File.ReadAllLines(); 按行读取，返回字符串数组
            Console.WriteLine("按行读取结果是：");
            for (int i = 0; i < str2.Length; i++)
            {
                Console.WriteLine(str2[i]);
            }
            Console.WriteLine();

            string str3 = File.ReadAllText(path4);            //(3)File.ReadAllText(path4);按文本读取，返回字符串 
            Console.WriteLine("按文本读取结果是：");
            Console.WriteLine(str3);
            Console.WriteLine();

            //文件写
            string str4 = "你好美啊！！";
            string path5 = "csharpWrite.txt";
            byte[] buffer2 = Encoding.Default.GetBytes(str4);  //Encoding.Default.GetBytes(),将字符串转为二进制字节数组
            File.WriteAllBytes(path5, buffer2);                 //（1）File.WriteAllBytes(path5,buffer2); 按字节写入；会覆盖之前内容

            string[] str5 = { "你好美啊！！", "你好丑啊！！", "你好傻啊！" };
            File.WriteAllLines(path5, str5);     //File.WriteAllLines(path5,str5);按行写入；str5 为 string[] 类型

            File.WriteAllText(path5, str4);    //File.WriteAllText(path5, str4);按字符串写入；str4为string类型

            File.AppendAllText(path5, "你被干掉了吗？");//追加写入

            //----Directory类
            //创建文件夹
            int count1 = 1;
            //Directory.CreateDirectory(@"F:\CSharpCode\directory"+ count1); //可以使用循环创建文件夹

            //删除文件夹
            // Directory.Delete(@"F:\CSharpCode\directory2");

            //判断文件夹是否存在
            bool b2 = Directory.Exists(@"F:\CSharpCode");
            Console.WriteLine("文件夹是否存在：{0}", b2);
            Console.WriteLine();

            //返回路径中的所有文件夹的路径
            string[] str6 = Directory.GetDirectories(@"F:\CSharpCode");
            foreach (string str in str6)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();

            //返回路径中的所有文件的路径
            string[] str7 = Directory.GetFiles(@"F:\CSharpCode");//Directory.GetFiles(@"F:\CSharpCode","*.txt");
            foreach (string str in str7)
            {
                Console.WriteLine("文件夹下文件路径是{0}", str);          //输出文件全路径
                int index = str.LastIndexOf('\\');  //找到'\'最后一次出现的索引
                Console.WriteLine("文件夹下文件名是{0}", str.Substring(index + 1)); //字符串截取，只输出文件名
            }
            Console.WriteLine();

            //----FileStream
            //创建文件读流对象
            using (FileStream fsRead1 = new FileStream(path4, FileMode.OpenOrCreate, FileAccess.Read))  //参数1：文件路径；参数2：打开；参数3：读取
            {
                //创建缓冲区大小
                byte[] buffer3 = new byte[fsRead1.Length]; //读小文件就设置流长度大小
                                                           //byte[] buffer3 = new byte[1024*1024*5]; //读取大文件根据需要设置大小
                                                           //开始读数据
                int realRead1 = fsRead1.Read(buffer3, 0, buffer3.Length);//第二个参数：偏移量，第三个参数：最多读取量；返回值：实际读取的数据
                                                                         //将字节数组转换为字符串
                string str8 = Encoding.Default.GetString(buffer3);
                Console.WriteLine("文件流读取结果是:");
                Console.WriteLine(str8);
            }
            //使用using代替手动关闭流和释放资源
            //fsRead1.Close();
            //fsRead1.Dispose();

            //案例，使FileStream类复制一个文件
            string targetPath1 = @"C:\Users\dell\Pictures\1.jpg";
            FileStreamCopy(path1, targetPath1);

            Console.WriteLine("使用文件流复制文件成功！");
            Console.WriteLine();

            //----Stream
            //流读取 
            FileStream fsRead2 = new FileStream(path4, FileMode.Open, FileAccess.Read);
            // StreamReader sr1 = new StreamReader(fsRead2);  // FileStream :Stream;里氏转换子类对象可以给父类对象赋值
            StreamReader sr1 = new StreamReader(path4, Encoding.Default);      //StreamReader 直接读取文本路径
            while (!sr1.EndOfStream)
            {
                Console.WriteLine(sr1.ReadLine());          //读取StreamReader字符                  
            }
            Console.WriteLine("使用StreamReader读取FileStream完成.");
            fsRead2.Close();
            fsRead2.Dispose();
            //流写入
            //string path6 = @"csharpWrite1.txt";
            // StreamWriter sw1 = new StreamWriter(@"F:\CSharpCode\Demo7\bin\Debug\net6.0\csharpWrite1.txt", true); //不覆盖写入
            FileStream fw11 = new FileStream(@"F:\CSharpCode\Demo7\写入练习.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw11 = new StreamWriter(fw11);
            sw11.Write("写了吗？");
            Console.WriteLine("写入成功！");
            sw11.Close();
            sw11.Dispose();

            Console.WriteLine();
            Console.ReadKey();
        }
        //使用FileStream类对大型文件进行赋值，参数一：源文件路径，参数二：保存目标文件路径
        public static void FileStreamCopy(string sourcePath, string targetPath)
        {
            FileStream fs1 = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);    //读流
            //创建文件写流对象
            FileStream ws1 = new FileStream(targetPath, FileMode.OpenOrCreate, FileAccess.Write);   //写流
            byte[] bufferCopy = new byte[1024 * 1024];      //创建缓存区
            while (true)
            {
                int realRead = fs1.Read(bufferCopy, 0, bufferCopy.Length);  //实际读取大小

                if (realRead == 0)                                          //无数据时退出
                {
                    return;
                }
                else
                {
                    ws1.Write(bufferCopy, 0, realRead);                     //有数据时写入，写入长度为实际读取大小
                }
            }



        }
    }
}