using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KBM.Web.Data
{
  
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { set; get; }

        [Required]
        [DisplayName("User Name")]
        public string UserName {set;get;}
        [DisplayName("Nama Lengkap")]
        public string Nama { get; set; }
        [DisplayName("Tanggal Lahir")]
        public DateTime? TanggalLahir { get; set; }
        [Description("Rentang Usia")]
        public string Kategori { get; set; }
        public string Telepon { get; set; }
        [DataType(DataType.MultilineText)]
        public string Alamat { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Kelompok { get; set; }

        public List<UserPerKelas> DataKelas { set; get; } 
        
    }

    public class UserPerKelas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserKelasId { set; get; }

    }

    public class Kelas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long KelasId { set; get; }
        public string Nama { get; set; }
        public string Pembina { get; set; }

        public List<UserPerKelas> DataUser { set; get; }

        public List<KelasPerMataPelajaran> DataPelajaran { set; get; }

    }
    public class KelasPerMataPelajaran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long KelasPelajaranId { set; get; }
    
      
    }

    public class Content
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContentId { set; get; }
        public string Judul { get; set; }
        [DisplayName("HTML / Multiline teks")]
        [DataType(DataType.MultilineText)]
        public string Konten { get; set; }
        [DisplayName("Link penunjang konten")]
        public string Links { get; set; }
        [DisplayName("Dokumen URL")]
        public string Dokumen { get; set; }
        [DisplayName("Tag pisahkan dengan ;")]

        public string Tags { get; set; }
        public string Kategori { get; set; }

        public List<MataPelajaranPerContent> DataPelajaran { set; get; }

    }

    public class MataPelajaranPerContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PelajaranContentId { set; get; }

    }
    public class MataPelajaran
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MataPelajaranId { set; get; }
        public string Nama { get; set; }
        public string Penyusun { get; set; }

        public List<KelasPerMataPelajaran> DataKelas { set; get; }
        public List<MataPelajaranPerContent> DataKonten { set; get; }
    }

    public class Ujian
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UjianId { set; get; }
        public UserProfile PesertaId { set; get; }
        public Kelas KelasId { set; get; }
        public MataPelajaran MataPelajaranId { set; get; }
        public Content ContentId { set; get; }
        public double Nilai { set; get; }
        [Description("Status: lulus / tidak lulus")]
        public string Status { set; get; }
        [Description("Tanggal ujian")]

        public DateTime Tanggal { set; get; }
    }

   

}
