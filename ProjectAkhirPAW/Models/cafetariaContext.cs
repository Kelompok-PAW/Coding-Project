using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectAkhirPAW.Models
{
    public partial class cafetariaContext : DbContext
    {
        public cafetariaContext()
        {
        }

        public cafetariaContext(DbContextOptions<cafetariaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chef> Chef { get; set; }
        public virtual DbSet<Kasir> Kasir { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Membayar> Membayar { get; set; }
        public virtual DbSet<Memilih> Memilih { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Pelanggan> Pelanggan { get; set; }
        public virtual DbSet<Pelayan> Pelayan { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=WINDOWS-C8ATAQL;Database=cafetaria;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chef>(entity =>
            {
                entity.HasKey(e => e.IdChef);

                entity.Property(e => e.IdChef).HasColumnName("ID_Chef");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kasir>(entity =>
            {
                entity.HasKey(e => e.IdKasir);

                entity.Property(e => e.IdKasir).HasColumnName("ID_Kasir");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.IdManager);

                entity.Property(e => e.IdManager).HasColumnName("ID_Manager");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Membayar>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.Property(e => e.IdTransaksi).HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdKasir).HasColumnName("ID_Kasir");

                entity.Property(e => e.IdPelanggan).HasColumnName("ID_Pelanggan");

                entity.Property(e => e.NotaPembayaran)
                    .HasColumnName("Nota_Pembayaran")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdKasirNavigation)
                    .WithMany(p => p.Membayar)
                    .HasForeignKey(d => d.IdKasir)
                    .HasConstraintName("FK_Membayar_Kasir");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.Membayar)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("FK_Membayar_Pelanggan");
            });

            modelBuilder.Entity<Memilih>(entity =>
            {
                entity.HasKey(e => e.IdMemilih);

                entity.Property(e => e.IdMemilih).HasColumnName("ID_Memilih");

                entity.Property(e => e.IdMenu).HasColumnName("ID_Menu");

                entity.Property(e => e.IdPelanggan).HasColumnName("ID_Pelanggan");

                entity.Property(e => e.JumlahPesanan).HasColumnName("Jumlah_Pesanan");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Memilih)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_Memilih_Menu");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.Memilih)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("FK_Memilih_Pelanggan");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.Property(e => e.IdMenu).HasColumnName("ID_Menu");

                entity.Property(e => e.Kategori)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaMakanan)
                    .HasColumnName("Nama_Makanan")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

                entity.Property(e => e.IdPelanggan).HasColumnName("ID_Pelanggan");

                entity.Property(e => e.IdPelayan).HasColumnName("ID_Pelayan");

                entity.Property(e => e.JumlahOrder).HasColumnName("Jumlah_Order");

                entity.HasOne(d => d.IdPelangganNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdPelanggan)
                    .HasConstraintName("FK_Order_Pelanggan");

                entity.HasOne(d => d.IdPelayanNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdPelayan)
                    .HasConstraintName("FK_Order_Pelayan");
            });

            modelBuilder.Entity<Pelanggan>(entity =>
            {
                entity.HasKey(e => e.IdPelanggan);

                entity.Property(e => e.IdPelanggan).HasColumnName("ID_Pelanggan");

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelayan>(entity =>
            {
                entity.HasKey(e => e.IdPelayan);

                entity.Property(e => e.IdPelayan).HasColumnName("ID_Pelayan");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
