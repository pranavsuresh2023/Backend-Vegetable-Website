using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AssignmentProject.Models;

public partial class AssignmentContext : DbContext
{
    public AssignmentContext()
    {
    }

    public AssignmentContext(DbContextOptions<AssignmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<Vegetable> Vegetables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserDeta__CB9A1CFF98C283F0");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("User_Password");
        });

        modelBuilder.Entity<Vegetable>(entity =>
        {
            entity.HasKey(e => e.VegId).HasName("PK__Vegetabl__0AE58580345EC31E");

            entity.Property(e => e.VegId).HasColumnName("Veg_Id");
            entity.Property(e => e.VegName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Veg_Name");

            entity.HasOne(d => d.User).WithMany(p => p.Vegetables)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Vegetable__UserI__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
