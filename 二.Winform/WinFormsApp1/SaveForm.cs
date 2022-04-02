using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class SaveForm               // static 资源共享相当于全局，不可实例化
    {
        public static Form1 _saveForm1;        //用静态字段存放Form1对象
    }
}
