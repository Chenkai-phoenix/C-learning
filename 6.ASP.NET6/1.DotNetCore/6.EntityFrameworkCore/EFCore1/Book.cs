﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1
{
    //搭建实体类（对象表）
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime PubTime { get; set; }
        public double Price { get; set; }
    }
}
