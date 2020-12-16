using System;
using System.Collections.Generic;

namespace ProjectAkhirPAW.Models
{
    public partial class Chef
    {
        public int IdChef { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Password { get; set; }
        public string JenisKelamin { get; set; }
    }
}
