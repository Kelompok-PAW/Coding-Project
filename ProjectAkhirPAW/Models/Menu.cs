using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Memilih = new HashSet<Memilih>();
        }

        public int IdMenu { get; set; }
        public string NamaMakanan { get; set; }
        public string Kategori { get; set; }
        public int? Harga { get; set; }

        public ICollection<Memilih> Memilih { get; set; }
    }
}
