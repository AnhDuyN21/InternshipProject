using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using File = Domain.Entities.File;

namespace Infrastructures;

public partial class InternshipProjectContext : DbContext
{
    public InternshipProjectContext()
    {
    }

    public InternshipProjectContext(DbContextOptions<InternshipProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Drive> Drives { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<Permisson> Permissons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersDrive> UsersDrives { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DBDefault"));
    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Drive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drives__3214EC076E29C5ED");

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('0')");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Owner).HasMaxLength(50);
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Files__3214EC07349C6EC9");

            entity.Property(e => e.FileType).HasMaxLength(50);

            entity.HasOne(d => d.Folder).WithMany(p => p.Files)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Files_Folders");
        });

        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Folders__3214EC07BBEDD6AD");

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('0')");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Drive).WithMany(p => p.Folders)
                .HasForeignKey(d => d.DriveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Folders_Drives");
        });

        modelBuilder.Entity<Permisson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permisso__3214EC072E1A5C7D");

            entity.ToTable("Permisson");

            entity.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValueSql("('0')");

            entity.HasOne(d => d.File).WithMany(p => p.Permissons)
                .HasForeignKey(d => d.FileId)
                .HasConstraintName("fk_Permission_Files");

            entity.HasOne(d => d.Folder).WithMany(p => p.Permissons)
                .HasForeignKey(d => d.FolderId)
                .HasConstraintName("fk_Permission_Folders");

            entity.HasOne(d => d.Role).WithMany(p => p.Permissons)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Permission_RoleId");

            entity.HasOne(d => d.User).WithMany(p => p.Permissons)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Permission_UserId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07629B05AF");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F920A3FE");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Users_Roles");
        });

        modelBuilder.Entity<UsersDrive>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users_Dr__3214EC0773694819");

            entity.ToTable("Users_Drives");

            entity.HasOne(d => d.Drive).WithMany(p => p.UsersDrives)
                .HasForeignKey(d => d.DriveId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserAndDrive_Drives");

            entity.HasOne(d => d.User).WithMany(p => p.UsersDrives)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserAndDrive_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
