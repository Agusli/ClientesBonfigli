using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Clientes.Models
{
    public partial class ClientesContext : DbContext
    {
        public ClientesContext()
        {
        }

        public ClientesContext(DbContextOptions<ClientesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<TipoCuenta> Tipos { get; set; }
        public virtual DbSet<WhatsAppConfig> WhatsAppConfig { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pantallas)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VencimientoC).HasColumnType("datetime");

                entity.Property(e => e.VencimientoP).HasColumnType("datetime");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UltimoAvisoPrevioUTC).HasColumnType("datetime");
                entity.Property(e => e.UltimoAvisoVencimientoUTC).HasColumnType("datetime");

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasColumnName("Token")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCuenta>(entity =>
            {
                entity.ToTable("Tipos");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Activo).HasDefaultValue(true);
            });

            modelBuilder.Entity<WhatsAppConfig>(entity =>
            {
                entity.ToTable("WhatsAppConfig");
                entity.Property(e => e.PrecioActual).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ServicioNombre).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.MetaVersion).HasDefaultValue("v20.0");
                entity.Property(e => e.MetaLanguageCode).HasMaxLength(20).HasDefaultValue("es_AR");
            });
        }

      
    }
}
