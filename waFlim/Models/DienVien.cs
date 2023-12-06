using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class DienVien
    {
        public DienVien()
        {
            MaPhims = new HashSet<Phim>();
        }

        public string TenDv { get; set; } = null!;

        public virtual ICollection<Phim> MaPhims { get; set; }
    }
}
