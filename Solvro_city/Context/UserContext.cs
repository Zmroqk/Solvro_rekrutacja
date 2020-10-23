using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solvro_city.Models;
using Microsoft.Extensions.Configuration;

namespace Solvro_city.Context
{
    /// <summary>
    /// User context of database
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Server configuration
        /// </summary>
        IConfiguration conf;

        /// <summary>
        /// User context constructor
        /// </summary>
        /// <param name="conf">Server confiuguration</param>
        public UserContext(IConfiguration conf)
        {
            this.conf = conf;
        }

        /// <summary>
        /// User table
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Configure Sqlite
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options) { options.UseSqlite($"Data Source=users.db;Password={conf["Db:Password"]};"); }
    }
}
