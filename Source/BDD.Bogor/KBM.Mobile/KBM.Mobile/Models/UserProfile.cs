
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
        //public UserPerKelas[] dataKelas { get; set; }
    }
    
    public class UserPerKelas
    {
        [PrimaryKey]
        [AutoIncrement]
        public long UserKelasId { set; get; }

    }

    public class Kelas
    {
        [PrimaryKey]
        [AutoIncrement]
        public long KelasId { set; get; }
        public string Nama { get; set; }
        public string Pembina { get; set; }

        public List<UserPerKelas> DataUser { set; get; }

        public List<KelasPerMataPelajaran> DataPelajaran { set; get; }

    }
    public class KelasPerMataPelajaran
    {
        [PrimaryKey]
        [AutoIncrement]
        public long KelasPelajaranId { set; get; }


    }

    public class Content
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ContentId { set; get; }
        public string Judul { get; set; }
       
        public string Konten { get; set; }
    
        public string Links { get; set; }
      
        public string Dokumen { get; set; }
     

        public string Tags { get; set; }
        public string Kategori { get; set; }

        public List<MataPelajaranPerContent> DataPelajaran { set; get; }

    }

    public class MataPelajaranPerContent
    {
        [PrimaryKey]
        [AutoIncrement]
        public long PelajaranContentId { set; get; }

    }
    public class MataPelajaran
    {
        [PrimaryKey]
        [AutoIncrement]
        public long MataPelajaranId { set; get; }
        public string Nama { get; set; }
        public string Penyusun { get; set; }

        public List<KelasPerMataPelajaran> DataKelas { set; get; }
        public List<MataPelajaranPerContent> DataKonten { set; get; }
    }

    public class Ujian
    {
        [PrimaryKey]
        [AutoIncrement]
        public long UjianId { set; get; }
        public UserProfile PesertaId { set; get; }
        public Kelas KelasId { set; get; }
        public MataPelajaran MataPelajaranId { set; get; }
        public Content ContentId { set; get; }
        public double Nilai { set; get; }
      
        public string Status { set; get; }
    

        public DateTime Tanggal { set; get; }
    }

}
