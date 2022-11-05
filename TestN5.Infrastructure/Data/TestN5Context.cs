using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestN5.Core.Entities;

namespace TestN5.Data.Data
{
    public partial class TestN5Context : DbContext
    {
        public TestN5Context()
        {
        }

        public TestN5Context(DbContextOptions<TestN5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Permissions> Permissions { get; set; } = null!;
        public virtual DbSet<PermissionType> PermissionTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.Property(e => e.EmployeeForname).HasColumnType("text");

                entity.Property(e => e.EmployeeSurname).HasColumnType("text");

                entity.Property(e => e.PermissionDate).HasColumnType("date");

                entity.HasOne(d => d.PermissionTypeDescription)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.PermissionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permissions_PermissionTypes");
            });

            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
