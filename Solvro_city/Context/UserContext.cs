using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solvro_city.Models;


namespace Solvro_city.Context
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) { options.UseSqlite("Data Source=users.db"); }
    }
}
