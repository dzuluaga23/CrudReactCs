﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPICrud.Models;

public partial class DbcrudContext : DbContext
{
    public DbcrudContext()
    {
    }

    public DbcrudContext(DbContextOptions<DbcrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__62AE35DDB7B8F50D");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("IdEMpleado");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
