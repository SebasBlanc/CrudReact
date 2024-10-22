using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPICrud.Models;

public partial class DbcrudTContext : DbContext
{
    public DbcrudTContext()
    {
    }

    public DbcrudTContext(DbContextOptions<DbcrudTContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro).HasName("PK__Libros__5BC0F02688D4A2E3");

            entity.Property(e => e.IdLibro).HasColumnName("idLibro");
            entity.Property(e => e.Editorial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("editorial");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
