using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UD27_Ej1.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Suministra> Suministras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pieza>(entity =>
            {

                entity.ToTable("Piezas");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).HasColumnName("Codigo");

                entity.Property(e => e.Nombre).HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.ToTable("Proveedores");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id")
                .HasMaxLength(4);

                entity.Property(e => e.Nombre).HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Suministra>(entity =>
            {
                entity.ToTable("Suministra");
                entity.HasKey(e => e.CodigoPieza);
                entity.HasKey(j => j.IdProveedor);

                entity.Property(e => e.CodigoPieza).HasColumnName("CodigoPieza");

                entity.Property(e => e.IdProveedor).HasColumnName("IdProveedor");

                entity.HasOne(d => d.Pieza)
                .WithMany(e => e.Suministras)
                .HasForeignKey(d => d.CodigoPieza)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Proveedor)
                .WithMany(e => e.Suministras)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull);
            }
            );
        }

    }
}
