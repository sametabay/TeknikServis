using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity;
using TeknikServis.Entity.Entities;
using TeknikServis.Entity.Entity;

namespace TeknikServis.BLL.Repository
{
   
    public class FotografRepo : RepositoryBase<Fotograf, int> { }
    public class MarkaRepo : RepositoryBase<Marka, int> { }
    public class ArizaRepo : RepositoryBase<Ariza, int> { }

}