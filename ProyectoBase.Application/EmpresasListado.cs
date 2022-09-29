using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public  class EmpresasListado
    {
        Data.EmpresasListado _EmpresasListado = new Data.EmpresasListado();
        public List<Models.EmpresasListado> SP_EmpresasListado()
        {
            return _EmpresasListado.SP_EmpresasListado();
        }
    }
}
