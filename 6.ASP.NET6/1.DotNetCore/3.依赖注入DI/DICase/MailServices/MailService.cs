using ConfigServices;
using LogServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailServices
{
    public class MailService : IMailService
    {
        private readonly ILogProvider log;
        private readonly IConfigServices config;
        public MailService(ILogProvider log, IConfigServices config)  
        {
            this.log = log;
            this.config = config;
        }
        public void send(string title, string to, string body)
        {
            this.log.LogInfo("准备发送邮件");
            string smtpServer = this.config.GetValue("SmtpServer");
            string userName = this.config.GetValue("Username");
            string password = this.config.GetValue("Password");
            Console.WriteLine($"邮件服务器地址是：{smtpServer}，{userName}，{password}。。。");
            Console.WriteLine($"发邮件啦{title}，给{to}，内容是{body}。。。");
            this.log.LogInfo("发送邮件完成");
        }
    }
}
