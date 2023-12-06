using System;
using System.Collections.Generic;

namespace waFlim.Models
{
    public partial class BinhLuan
    {
        public int MaBinhLuan { get; set; }
        public string? NdBinhLuan { get; set; }
        public int? MaPhim { get; set; }
        public int? MaNguoiDung { get; set; }

        public virtual NguoiDung? MaNguoiDungNavigation { get; set; }
    }
}
