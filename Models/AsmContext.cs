using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AssignmentCsharp4_hieuptph18134.Models
{
    public partial class AsmContext : DbContext
    {
        public AsmContext()
        {
        }

        public AsmContext(DbContextOptions<AsmContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G49QDEM\\SQLEXPRESS;Database=Asm;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDanhMuc);

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDanhMuc)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenDanhMuc).HasMaxLength(50);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHoaDon)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaKhachHang)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NgayBan).HasColumnType("datetime");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_KhachHang");
            });

            modelBuilder.Entity<HoaDonChiTiet>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonCt);

                entity.ToTable("HoaDonChiTiet");

                entity.Property(e => e.MaHoaDonCt)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Anh).HasMaxLength(50);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.MaHoaDon)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenSanPham).HasMaxLength(50);

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDonChiTiet_HoaDon");

                entity.HasOne(d => d.MaSanPhamNavigation)
                    .WithMany(p => p.HoaDonChiTiets)
                    .HasForeignKey(d => d.MaSanPham)
                    .HasConstraintName("FK_HoaDonChiTiet_SanPham");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang);

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.TenKhachHang)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSanPham);

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSanPham)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Anh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.MaDanhMuc)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenSanPham)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaDanhMucNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDanhMuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_DanhMuc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
