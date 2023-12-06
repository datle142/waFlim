using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            BinhLuans = new HashSet<BinhLuan>();
            Phims = new HashSet<Phim>();
        }

        public int MaNguoiDung { get; set; }
        public string? Username { get; set; }
        public string? Pssword { get; set; }
        public string? Email { get; set; }
        public string? TenNguoiDung { get; set; }

        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
        public virtual ICollection<Phim> Phims { get; set; }
    }
}
