using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = ProyectoBase.Models;

namespace ProyectoBase.Models.Business
{
        public class status : Repository.StatusRepository { 


            public List<mod.Status> Seleccionar_Status()
        {
            return Seleccionar();
        }


    }
}