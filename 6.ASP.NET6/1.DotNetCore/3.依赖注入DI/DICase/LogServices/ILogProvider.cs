using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServices
{
    public interface ILogProvider
    {
        void LogError(string msg); //接口默认public，不允许写其他修饰符
        public void LogInfo(string msg);
    }
}
