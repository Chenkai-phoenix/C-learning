//命名空间的使用
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*----构造函数
 * （1）构造函数没有返回值，定义的时候void也不写；
 * （2）构造函数的函数名必须与类名一致；
 * （3）创建对象时自动执行构造函数；
 * （4）构造函数可以重载；
 *      4.1>类默认自带一个无参空的构造函数，
 *      4.2>当自定义新的构造函数时，默认的无参构造函数被干掉;
 *      4.3>如过需要无参构造，还要自己写重载
 *----析构函数 ~类名
 *  （1）当程序结束时执行
 *   (2)用于资源释放；.net有专门的垃圾回收器（GC），自动但是不一定有实效性，如果对资源释放有要求则用析构函数手动释放；
 */
namespace Demo5
{
    public class Student
    {
        //字段
        private string _name;
        private int _age;
        private char _gender;
        private int _mathScore;
        private int _chineseScore;
        private int _englishScore;
        //属性
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                    _age = 0;
                else
                    _age = value;
            }
        }
        public char Gender
        {
            get { return _gender; }
            set
            {
                if (value != '男' && value != '女')
                    _gender = '＊';
                else
                    _gender = value;
            }
        }
        public int MathScore
        {
            get { return _mathScore; }
            set { _mathScore = value; }
        }
        public int ChineseScore
        {
            get { return _chineseScore; }
            set { _chineseScore = value; }
        }
        public int EnglishScore
        {
            get { return _englishScore; }
            set { _englishScore = value; }
        }
        //构造函数(用于对象的初始化)
        public Student() //无参构造函数(默认的已经被干掉了)
        { }
        public Student(string name,int age,char gender,int mathScore,int chineseSore,int englishScore)  //构造函数重载
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
            this.MathScore = mathScore;
            this.ChineseScore = chineseSore;
            this.EnglishScore = englishScore;
        }
        //构造函数重载：this()显示的调用构造函数
        public Student(string name, int age, char gender, int englishScore) :this(name,age,gender,0,0,englishScore)
        {
        }
        //析构函数
        ~Student()
        {
            Console.WriteLine("资源已释放");
        }
        //方法
        public void SayHello()
        {
            Console.WriteLine("你好我叫{0}，今年{1}岁，性别{2}！", this.Name, this.Age, this.Gender);
        }
        public void ScoresPrint()
        {
            Console.WriteLine("数学成绩是{0}", this.MathScore);
            Console.WriteLine("语文成绩是{0}", this.ChineseScore);
            Console.WriteLine("英语成绩是{0}", this.EnglishScore);
            Console.WriteLine("总成绩是{0}", this.MathScore + this.ChineseScore + this.EnglishScore);
        }

    }
}
