using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class Trailer
    {
        public Trailer()
        {
            Phims = new HashSet<Phim>();
        }

        public int MaTrailer { get; set; }
        public string? TenTrailer { get; set; }

        public virtual ICollection<Phim> Phims { get; set; }
    }
}
