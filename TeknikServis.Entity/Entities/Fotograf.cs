using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.Entity
{
    [Table("Fotograflar")]
    public class Fotograf
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Yol { get; set; }
        public int ArizaID { get; set; }
        [ForeignKey("ArizaID")]
        public virtual Ariza Arizasi { get; set; }
    }
}
