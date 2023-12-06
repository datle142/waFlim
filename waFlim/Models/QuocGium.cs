using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class QuocGium
    {
        public QuocGium()
        {
            Phims = new HashSet<Phim>();
        }

        public string TenQuocGia { get; set; } = null!;

        public virtual ICollection<Phim> Phims { get; set; }
    }
}
