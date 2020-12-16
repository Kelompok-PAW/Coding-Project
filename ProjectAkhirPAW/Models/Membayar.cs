using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Membayar
    {
        public int IdTransaksi { get; set; }
        public string NotaPembayaran { get; set; }
        public int? IdKasir { get; set; }
        public int? IdPelanggan { get; set; }

        public Kasir IdKasirNavigation { get; set; }
        public Pelanggan IdPelangganNavigation { get; set; }
    }
}
