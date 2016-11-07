using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity
{
    [Table("Arizalar")]
   public class Ariza
    {
        [Key]
        public int ArizaID { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Adres { get; set; }
        public string Rapor { get; set; }
        public string FotografYolu { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public bool OnaylandiMi { get; set; } = false;
        public DateTime OnaylanmaTarihi { get; set; }

    }
}
