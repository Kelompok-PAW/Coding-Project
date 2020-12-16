using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Memilih
    {
        public int IdMemilih { get; set; }
        public int? IdMenu { get; set; }
        public int? IdPelanggan { get; set; }
        public int? JumlahPesanan { get; set; }

        public Menu IdMenuNavigation { get; set; }
        public Pelanggan IdPelangganNavigation { get; set; }
    }
}
