using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Models;

namespace Services
{
    public class CalcContext : DbContext
    {
        public CalcContext()
            :base("DefaultConnection")
        {
      
        }

        public DbSet<OperationResult> OperationResult { get; set; } //связывает нашу таблицу с классом

        public DbSet<Operation> Operations { get; set; } //связывает нашу таблицу с классом
    }
}