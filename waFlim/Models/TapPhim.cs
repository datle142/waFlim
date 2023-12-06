using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class TapPhim
    {
        public TapPhim()
        {
            Phims = new HashSet<Phim>();
        }

        public int MaTap { get; set; }
        public int? TenTap { get; set; }

        public virtual ICollection<Phim> Phims { get; set; }
    }
}
