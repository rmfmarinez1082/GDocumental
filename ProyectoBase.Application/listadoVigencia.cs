using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class listadoVigencia
    {
        Data.listadoVigencia _Listarvigencia = new Data.listadoVigencia();

        public List<Models.listadoVigencia> SP_listadoVigente(Models.listadoVigencia listarvigente)
        {
            return _Listarvigencia.SP_listadoVigente(listarvigente);
        }

        public List<Models.listadoVigencia> SP_listadoVencido(Models.listadoVigencia listarvencido)
        {
            return _Listarvigencia.SP_listadoVencido(listarvencido);
        }


        public List<Models.listadoVigencia> SP_LisProxVence(Models.listadoVigencia listarProxvenc)
        {
            return _Listarvigencia.SP_LisProxVence(listarProxvenc);
        }
    }
}
