
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KBM.Mobile.Models
{
    
    public class UserProfile
    {
        [PrimaryKey, AutoIncrement]
        public int userId { get; set; }
        public string userName { get; set; }
        public string nama { get; set; }
        public DateTime tanggalLahir { get; set; }
        public string kategori { get; set; }
        public string telepon { get; set; }
        public string alamat { get; set; }
        public string email { get; set; }
        public string kelompok { get; set; }
        public Datakelas[] dataKelas { get; set; }
    }

    public class Datakelas
    {
        public int userKelasId { get; set; }
    }
}
