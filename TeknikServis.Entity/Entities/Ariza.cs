using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entity;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.Entity
{
    [Table("Arizalar")]
   public class Ariza
    {
        [Key]
        public int ArizaID { get; set; }
        [StringLength(66)]
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Adres { get; set; }
        public string Rapor { get; set; }       
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public DateTime? OnaylanmaTarihi { get; set; }
        public DateTime? OnarimTarihi { get; set; }
        public string KullaniciID { get; set; }
        public string OperatorID { get; set; }
        public string TeknisyenID { get; set; }


        [ForeignKey("KullaniciID")]
        public virtual ApplicationUser Sahibi { get; set; }

        [ForeignKey("OperatorID")]
        public virtual ApplicationUser Operatoru { get; set; }
        [ForeignKey("TeknisyenID")]
        public virtual ApplicationUser Teknisyeni { get; set; }
        public virtual List<Fotograf> Fotograflar { get; set; } = new List<Fotograf>();



    }
}
