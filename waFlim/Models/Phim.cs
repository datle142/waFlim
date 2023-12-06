using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class Phim
    {
        public Phim()
        {
            MaTheLoais = new HashSet<TheLoai>();
            TenDvs = new HashSet<DienVien>();
        }

        public int MaPhim { get; set; }
        public string TenPhim { get; set; } = null!;
        public DateTime? NgayRaMat { get; set; }
        public bool? TrangThai { get; set; }
        public string MoTa { get; set; } = null!;
        public string? NguonPhim { get; set; }
        public short? DanhGia { get; set; }
        public int? MaTrailer { get; set; }
        public int? MaAdmin { get; set; }
        public string? TenDv { get; set; }
        public int? MaTap { get; set; }
        public int? MaNguoiDung { get; set; }
        public string? TenQuocGia { get; set; }

        public virtual Admin? MaAdminNavigation { get; set; }
        public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
        public virtual TapPhim? MaTapNavigation { get; set; }
        public virtual Trailer? MaTrailerNavigation { get; set; }
        public virtual QuocGium? TenQuocGiaNavigation { get; set; }

        public virtual ICollection<TheLoai> MaTheLoais { get; set; }
        public virtual ICollection<DienVien> TenDvs { get; set; }
    }
}
