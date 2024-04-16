using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudByApi.Models;

public partial class DocumentDbContext : DbContext
{   
    //Run to generate DBContext
    // Scaffold-DbContext
    // "Server=DESKTOP-4J6IQKA\SQLEXPRESS01;Database=DocumentDb;Integrated Security=True;TrustServerCertificate=True" 
    //  Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
    public DocumentDbContext()
    {
    }

    public DocumentDbContext(DbContextOptions<DocumentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppRole> AppRoles { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<AppUserRole> AppUserRoles { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Employee> EmployeeMaster { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4J6IQKA\\SQLEXPRESS01;Database=DocumentDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasIndex(e => e.DeparmentId, "IX_AppUsers_DeparmentId");
            entity.Property(e => e.Email).HasMaxLength(70);
            entity.Property(e => e.FirstName).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(15);
            entity.Property(e => e.Password).HasMaxLength(25);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(25);

            entity.HasOne(d => d.Deparment).WithMany(p => p.AppUsers).HasForeignKey(d => d.DeparmentId);
        });

        modelBuilder.Entity<AppUserRole>(entity =>
        {
            entity.HasIndex(e => e.AppRoleId, "IX_AppUserRoles_AppRoleId");

            entity.HasIndex(e => new { e.AppUserId, e.AppRoleId }, "IX_AppUserRoles_AppUserId_AppRoleId").IsUnique();

            entity.HasOne(d => d.AppRole).WithMany(p => p.AppUserRoles).HasForeignKey(d => d.AppRoleId);

            entity.HasOne(d => d.AppUser).WithMany(p => p.AppUserRoles).HasForeignKey(d => d.AppUserId);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Definition).HasMaxLength(30);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasIndex(e => e.AppUserId, "IX_Documents_AppUserId");

            entity.Property(e => e.ClassOfDoc).HasMaxLength(30);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.IsBorrowed).HasColumnName("isBorrowed");
            entity.Property(e => e.TypeOfDoc).HasMaxLength(30);

            entity.HasOne(d => d.AppUser).WithMany(p => p.Documents).HasForeignKey(d => d.AppUserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
