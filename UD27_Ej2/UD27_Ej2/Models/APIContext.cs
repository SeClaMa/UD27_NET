﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UD27_Ej2.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Cientifico> Cientificos { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }
        public virtual DbSet<Asignado_a> Asignados_A { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cientifico>(entity =>
            {

                entity.ToTable("Cientificos");
                entity.HasKey(e => e.DNI);
                entity.Property(e => e.DNI).HasColumnName("dni");

                entity.Property(e => e.NomApels).HasColumnName("nomApels")
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {

                entity.ToTable("Proyecto");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre).HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.Horas).HasColumnName("horas");

                
            });

            modelBuilder.Entity<Asignado_a>(entity =>
            {
                entity.ToTable("Asignado_a");
                entity.HasKey(e => e.IdCientifico);
                entity.HasKey(f => f.IdProyecto);

                entity.Property(e => e.IdCientifico).HasColumnName("cientifico");

                entity.Property(e => e.IdProyecto).HasColumnName("proyecto");

                entity.HasOne(d => d.Cientifico)
                .WithMany(e => e.Asignados_a)
                .HasForeignKey(d => d.IdCientifico)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Proyecto)
                .WithMany(e => e.Asignados_a)
                .HasForeignKey(d => d.IdProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
