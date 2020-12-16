using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Pelayan
    {
        public Pelayan()
        {
            Order = new HashSet<Order>();
        }

        public int IdPelayan { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Password { get; set; }
        public string JenisKelamin { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
