using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Context
{
   
    public class VaultDBContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Invesment> Invesments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
            optionsBuilder.UseMySql(
                "server=127.0.0.1;database=vaultdb;uid=root;pwd=1907genclik;",  ServerVersion.AutoDetect("server=127.0.0.1;database=vaultdb;uid=root;pwd=1907genclik;"));
        }
    }

    [Table("expense")]
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCredit { get; set; }
        public DateTime Date { get; set; }
    }

    [Table("invesment")]
    public class Invesment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Quantity { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }


}
