using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = ProyectoBase.Models;


namespace ProyectoBase.Models.Business
{
    public class ClasificacionDoc : Repository.ClasificacionDocRepository
    {
     

        public List<mod.ClasificacionDoc> Seleccionar_clas()
        {
            return Seleccionar();
        }

 
    }
}
