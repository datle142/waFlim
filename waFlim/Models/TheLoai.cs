using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class TheLoai
    {
        public TheLoai()
        {
            MaPhims = new HashSet<Phim>();
        }

        public int MaTheLoai { get; set; }
        public string? TenTheLoai { get; set; }

        public virtual ICollection<Phim> MaPhims { get; set; }
    }
}
