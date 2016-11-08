using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.Entity;

namespace TeknikServis.Entity.Entities
{
    [Table("Markalar")]
    public class Marka
    {
        [Key]
        public int ID { get; set; }
        [StringLength(40)]
        public string MarkaAdi { get; set; }

        public virtual List<Fotograf> Fotograflar { get; set; } = new List<Fotograf>();
    }
}
