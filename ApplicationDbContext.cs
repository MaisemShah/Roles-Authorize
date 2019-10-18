using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test1.Data;

namespace Test1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Test1.Data.Food> Food { get; set; }
        public DbSet<Test1.Data.Drink> Drink { get; set; }
        public object Drinks { get; internal set; }
    }
}
