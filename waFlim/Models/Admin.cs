using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace waFlim.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Phims = new HashSet<Phim>();
        }

        public int MaAdmin { get; set; }
        public string? Username { get; set; }
        public string? Pssword { get; set; }

        public virtual ICollection<Phim> Phims { get; set; }
    }
}
