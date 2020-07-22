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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KUAIQE3;Initial Catalog=Clientes;Integrated Security=True");
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
            });
        }
    }
}
