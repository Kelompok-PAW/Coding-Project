using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int? JumlahOrder { get; set; }
        public int? IdPelanggan { get; set; }
        public int? IdPelayan { get; set; }

        public Pelanggan IdPelangganNavigation { get; set; }
        public Pelayan IdPelayanNavigation { get; set; }
    }
}
