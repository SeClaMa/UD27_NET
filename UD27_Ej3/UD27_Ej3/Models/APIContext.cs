using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UD27_Ej3.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Cajero> Cajeros { get; set; }
        public virtual DbSet<Maquina_Registradora> Maquinas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajero>(entity =>
            {

                entity.ToTable("Cajeros");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.NomApels).HasColumnName("nomApels")
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {

                entity.ToTable("Productos");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nombre).HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");
                
            });

            modelBuilder.Entity<Maquina_Registradora>(entity =>
            {

                entity.ToTable("Maquinas_registradoras");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Piso).HasColumnName("piso");

            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("Venta");
                entity.HasKey(e => e.IdCajero);
                entity.HasKey(f => f.IdMaquina);
                entity.HasKey(j => j.IdProducto);


                entity.Property(e => e.IdCajero).HasColumnName("cajero");

                entity.Property(e => e.IdMaquina).HasColumnName("maquina");

                entity.Property(e => e.IdProducto).HasColumnName("producto");


                entity.HasOne(d => d.Cajero)
                .WithMany(e => e.Ventas)
                .HasForeignKey(d => d.IdCajero)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Maquina)
                .WithMany(e => e.Ventas)
                .HasForeignKey(d => d.IdMaquina)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Producto)
                .WithMany(e => e.Ventas)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
