using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    //搭建配置类（对象表到数据库表的映射）
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");   //Book实体与T_Books表的映射 ORM
            builder.Property(e => e.Title).HasMaxLength(50).IsRequired(); //设置表中字段的属性
        }
    }
}
