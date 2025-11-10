using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyOrganizationApp.Domain.Entities;

namespace MyOrganizationApp.Infrastructure.Data;

public partial class MyOrgDbContext : DbContext
{
    public MyOrgDbContext()
    {
    }

    public MyOrgDbContext(DbContextOptions<MyOrgDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDepartment> TblDepartments { get; set; }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDepartment>(entity =>
        {
            entity.HasKey(e => e.PkdeptId);

            entity.ToTable("Tbl_Department");

            entity.Property(e => e.PkdeptId).HasColumnName("PKDeptID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.HasKey(e => e.PkempId);

            entity.ToTable("Tbl_Employee");

            entity.Property(e => e.PkempId).HasColumnName("PKEmpID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FkdeptId).HasColumnName("FKDeptID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Fkdept).WithMany(p => p.TblEmployees)
                .HasForeignKey(d => d.FkdeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tbl_Department_Tbl_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
