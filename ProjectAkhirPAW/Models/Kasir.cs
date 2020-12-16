using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Kasir
    {
        public Kasir()
        {
            Membayar = new HashSet<Membayar>();
        }

        public int IdKasir { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Password { get; set; }
        public string JenisKelamin { get; set; }

        public ICollection<Membayar> Membayar { get; set; }
    }
}
