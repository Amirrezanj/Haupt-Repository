using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoProject.Data.Entities;

namespace TodoProject.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresse{ get; set; }
        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create((options) =>
        {
            options.AddDebug();
        });
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\Amirreza\\Desktop\\Modul3-Aufgabe\\TodoProject.db")
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(_loggerFactory);
        }
    }
}
