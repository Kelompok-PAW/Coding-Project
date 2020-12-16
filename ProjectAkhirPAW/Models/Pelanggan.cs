using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Pelanggan
    {
        public Pelanggan()
        {
            Membayar = new HashSet<Membayar>();
            Memilih = new HashSet<Memilih>();
            Order = new HashSet<Order>();
        }

        public int IdPelanggan { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }

        public ICollection<Membayar> Membayar { get; set; }
        public ICollection<Memilih> Memilih { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
