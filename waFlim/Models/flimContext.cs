using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace waFlim.Models
{
    public partial class flimContext : DbContext
    {
        public flimContext()
        {
        }

        public flimContext(DbContextOptions<flimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<BinhLuan> BinhLuans { get; set; } = null!;
        public virtual DbSet<DienVien> DienViens { get; set; } = null!;
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; } = null!;
        public virtual DbSet<Phim> Phims { get; set; } = null!;
        public virtual DbSet<QuocGium> QuocGia { get; set; } = null!;
        public virtual DbSet<TapPhim> TapPhims { get; set; } = null!;
        public virtual DbSet<TheLoai> TheLoais { get; set; } = null!;
        public virtual DbSet<Trailer> Trailers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=MSI;Initial Catalog=flim;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.MaAdmin)
                    .HasName("PK__Admin__B59817FAB6CDB5F3");

                entity.ToTable("Admin");

                entity.Property(e => e.MaAdmin)
                    .ValueGeneratedNever()
                    .HasColumnName("maAdmin");

                entity.Property(e => e.Pssword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pssword");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.HasKey(e => e.MaBinhLuan)
                    .HasName("PK__BinhLuan__CF056B66B49ECE1C");

                entity.ToTable("BinhLuan");

                entity.Property(e => e.MaBinhLuan)
                    .ValueGeneratedNever()
                    .HasColumnName("maBinhLuan");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.MaPhim).HasColumnName("maPhim");

                entity.Property(e => e.NdBinhLuan)
                    .HasMaxLength(200)
                    .HasColumnName("ndBinhLuan");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.BinhLuans)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_BinhLuan_NguoiDung");
            });

            modelBuilder.Entity<DienVien>(entity =>
            {
                entity.HasKey(e => e.TenDv)
                    .HasName("PK__DienVien__4CF96561FE69706F");

                entity.ToTable("DienVien");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(50)
                    .HasColumnName("TenDV");

                entity.HasMany(d => d.MaPhims)
                    .WithMany(p => p.TenDvs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Dien",
                        l => l.HasOne<Phim>().WithMany().HasForeignKey("MaPhim").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Dien_Phim"),
                        r => r.HasOne<DienVien>().WithMany().HasForeignKey("TenDv").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Dien_DienVien"),
                        j =>
                        {
                            j.HasKey("TenDv", "MaPhim").HasName("PK__Dien__550AEA02CC791767");

                            j.ToTable("Dien");

                            j.IndexerProperty<string>("TenDv").HasMaxLength(50).HasColumnName("TenDV");

                            j.IndexerProperty<int>("MaPhim").HasColumnName("maPhim");
                        });
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.MaNguoiDung)
                    .HasName("PK__NguoiDun__446439EA3F6A8550");

                entity.ToTable("NguoiDung");

                entity.Property(e => e.MaNguoiDung)
                    .ValueGeneratedNever()
                    .HasColumnName("maNguoiDung");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Pssword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pssword");

                entity.Property(e => e.TenNguoiDung)
                    .HasMaxLength(50)
                    .HasColumnName("tenNguoiDung");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Phim>(entity =>
            {
                entity.HasKey(e => e.MaPhim)
                    .HasName("PK__Phim__9F38F63081EB7A3A");

                entity.ToTable("Phim");

                entity.Property(e => e.MaPhim)
                    .ValueGeneratedNever()
                    .HasColumnName("maPhim");

                entity.Property(e => e.DanhGia).HasColumnName("danhGia");

                entity.Property(e => e.MaAdmin).HasColumnName("maAdmin");

                entity.Property(e => e.MaNguoiDung).HasColumnName("maNguoiDung");

                entity.Property(e => e.MaTap).HasColumnName("maTap");

                entity.Property(e => e.MaTrailer).HasColumnName("maTrailer");

                entity.Property(e => e.MoTa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("moTa");

                entity.Property(e => e.NgayRaMat)
                    .HasColumnType("date")
                    .HasColumnName("ngayRaMat");

                entity.Property(e => e.NguonPhim)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nguonPhim");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(50)
                    .HasColumnName("TenDV");

                entity.Property(e => e.TenPhim)
                    .HasMaxLength(200)
                    .HasColumnName("tenPhim");

                entity.Property(e => e.TenQuocGia)
                    .HasMaxLength(50)
                    .HasColumnName("tenQuocGia");

                entity.Property(e => e.TrangThai).HasColumnName("trangThai");

                entity.HasOne(d => d.MaAdminNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaAdmin)
                    .HasConstraintName("FK_Phim_Admin");

                entity.HasOne(d => d.MaNguoiDungNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaNguoiDung)
                    .HasConstraintName("FK_Phim_NguoiDung");

                entity.HasOne(d => d.MaTapNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaTap)
                    .HasConstraintName("FK_Phim_TapPhim");

                entity.HasOne(d => d.MaTrailerNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaTrailer)
                    .HasConstraintName("FK_Phim_Trailer");

                entity.HasOne(d => d.TenQuocGiaNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.TenQuocGia)
                    .HasConstraintName("FK_Phim_QuocGia");

                entity.HasMany(d => d.MaTheLoais)
                    .WithMany(p => p.MaPhims)
                    .UsingEntity<Dictionary<string, object>>(
                        "Tlphim",
                        l => l.HasOne<TheLoai>().WithMany().HasForeignKey("MaTheLoai").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TLPhim_TheLoai"),
                        r => r.HasOne<Phim>().WithMany().HasForeignKey("MaPhim").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_TLPhim_Phim"),
                        j =>
                        {
                            j.HasKey("MaPhim", "MaTheLoai").HasName("PK__TLPhim__6DD11457CED4ED53");

                            j.ToTable("TLPhim");

                            j.IndexerProperty<int>("MaPhim").HasColumnName("maPhim");

                            j.IndexerProperty<int>("MaTheLoai").HasColumnName("maTheLoai");
                        });
            });

            modelBuilder.Entity<QuocGium>(entity =>
            {
                entity.HasKey(e => e.TenQuocGia);

                entity.Property(e => e.TenQuocGia)
                    .HasMaxLength(50)
                    .HasColumnName("tenQuocGia");
            });

            modelBuilder.Entity<TapPhim>(entity =>
            {
                entity.HasKey(e => e.MaTap)
                    .HasName("PK__TapPhim__0FC5486A4DD73A2B");

                entity.ToTable("TapPhim");

                entity.Property(e => e.MaTap)
                    .ValueGeneratedNever()
                    .HasColumnName("maTap");

                entity.Property(e => e.TenTap).HasColumnName("tenTap");
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.MaTheLoai)
                    .HasName("PK__TheLoai__2E9E267E4B2E18B2");

                entity.ToTable("TheLoai");

                entity.Property(e => e.MaTheLoai)
                    .ValueGeneratedNever()
                    .HasColumnName("maTheLoai");

                entity.Property(e => e.TenTheLoai)
                    .HasMaxLength(50)
                    .HasColumnName("tenTheLoai");
            });

            modelBuilder.Entity<Trailer>(entity =>
            {
                entity.HasKey(e => e.MaTrailer)
                    .HasName("PK__Trailer__90C4C905E0C15AB4");

                entity.ToTable("Trailer");

                entity.Property(e => e.MaTrailer)
                    .ValueGeneratedNever()
                    .HasColumnName("maTrailer");

                entity.Property(e => e.TenTrailer)
                    .HasMaxLength(50)
                    .HasColumnName("tenTrailer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
