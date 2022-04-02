using System;
/*
 * 一、ORM
1.object ralational mapping:通过操作对象的形式操作关系数据库
2.EFcore是微软官方的ORM框架，操作关系型数据库；
3.EFcore搭建环境
NUGET:Microsoft.EntityFrameworkCore.SqlServer
（1）搭建实体类
（2）搭建配置类继承 : IEntityTypeConfiguration<T>实现Configure（）；//可以不写，会自动使用dotnet提供的默认约定
（3）搭建DbContext：
a>声明搭建的实体类;
b>重写OnConfiguring（） ；设置要连接的数据库
c>重写OnModelCreating（）；设置要加载实例的程序集

（4）生成数据库，使用Migration(迁移)，根据实体类自动生成数据库中的表
nuget：Microsoft.EntityFrameworkCore.Tools
程序集控制台：Add-Migration XXX （生成迁移代码）
              update-database （更新到数据库）
（5）调用EF Core的业务代码

 */

namespace EFCore1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
