using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    //搭建DbContext
    public class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //数据库连接字符串
            optionsBuilder.UseSqlServer("Server=.;Database=EFCoreDemo1;Trusted_Connection=True;MultipleActiveResultSets=true"); 
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            //加载当前程序集中所有的IEntityTypeConfiguration
            modelbuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
