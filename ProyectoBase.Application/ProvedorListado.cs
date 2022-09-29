using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
   public class ProvedorListado
    {
        Data.ProvedorListado _ProvedorListado = new Data.ProvedorListado();
        public List<Models.ProvedorListado> SP_ProvedoresListado()
        {
            return _ProvedorListado.SP_ProvedoresListado();
        }
    }
}
