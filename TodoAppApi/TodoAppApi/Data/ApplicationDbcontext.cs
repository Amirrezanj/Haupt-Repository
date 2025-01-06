using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TodoAppApi.Data.Entities;

namespace TodoAppApi.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<TodoEntity> Todos { get; set; }

    private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create((options) =>
    {
        options.AddDebug();
    });

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        var dbPath = Path.Combine(desktopPath, "todo_project.db");

        optionsBuilder.UseSqlite($"Data Source={dbPath}")
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(_loggerFactory);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.ToTable("users");
            entity.Property(entity => entity.Id).HasColumnName("id");
            entity.Property(entity => entity.FirstName).HasColumnName("firstName").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.SecondName).HasColumnName("secondName").HasMaxLength(60);
            entity.Property(entity => entity.LastName).HasColumnName("lastName").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.Email).HasColumnName("email").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.FirstName).HasColumnName("firstNumber").IsRequired().HasMaxLength(60);
        });
        modelBuilder.Entity<AddressEntity>(entity =>
        {
            entity.ToTable("addresses");
            entity.Property(entity => entity.Id).HasColumnName("id");
            entity.Property(entity => entity.Street).HasColumnName("street").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.HouseNumber).HasColumnName("houseNumber").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.City).HasColumnName("city").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.Id).HasColumnName("id").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.ZipCode).HasColumnName("zipCode").IsRequired().HasMaxLength(60);
            entity.Property(entity => entity.Country).HasColumnName("country").IsRequired().HasMaxLength(60);
        });
        modelBuilder.Entity<TodoEntity>(entity =>
        {
            entity.ToTable("todo");
            entity.Property(entity => entity.Id).HasColumnName("id");
            entity.Property(entity => entity.DueDate).HasColumnName("dueDate");
            entity.Property(entity => entity.Description).HasColumnName("description");
        });
    }
}