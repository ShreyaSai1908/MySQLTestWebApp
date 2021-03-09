using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLTestWebApp1.Models.Database
{
    public class AppDbContext : DbContext
    {
        private readonly string serverName = "localhost";
        private readonly string port = "3306";
        private readonly string user = "root";
        private readonly string password = "mysql@123";
        private readonly string database = "TeacherDB";
        private string connectionString;
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connectionString = "server=" + serverName + ";" +
                                "port=" + port + ";" +
                                "user=" + user + ";" +
                                "password=" + password + ";" +
                                "database=" + database;
            optionsBuilder
                .UseMySql(connectionString)
                .UseLoggerFactory(LoggerFactory.Create(b => b
                     .AddConsole()
                     .AddFilter(level => level >= LogLevel.Information)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
    }
}
