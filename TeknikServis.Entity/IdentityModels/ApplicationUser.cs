using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis.Entity.IdentityModels
{
    public class ApplicationUser: IdentityUser
    {
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(35)]
        public string Surname { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;
        public string ActivationCode { get; set; }
        public string PreRole { get; set; }

        public virtual List<Ariza> Arizalar { get; set; } = new List<Ariza>();
    }
}
