using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Data;

public partial class TodoProjectContext : DbContext
{
    public TodoProjectContext()
    {
    }

    public TodoProjectContext(DbContextOptions<TodoProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\ITAD2-TN15\\Desktop\\todo_project.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("addresses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.HouseNumber).HasColumnName("houseNumber");
            entity.Property(e => e.Street).HasColumnName("street");
            entity.Property(e => e.ZipCode).HasColumnName("zipCode");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.AddressId, "IX_users_AddressId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstNumber).HasColumnName("firstNumber");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.SecondName).HasColumnName("secondName");

            entity.HasOne(d => d.Address).WithMany(p => p.Users).HasForeignKey(d => d.AddressId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
