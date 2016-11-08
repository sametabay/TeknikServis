using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity;
using TeknikServis.Entity.Entity;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.DAL
{
    public class ArizaContext:IdentityDbContext<ApplicationUser>
    {
        public ArizaContext():base("name=ArizaCon")
        { }
        public virtual DbSet<Ariza> Arizalar { get; set; }
        public virtual DbSet<Fotograf> Fotograflar { get; set; }
    }
    
   

}
