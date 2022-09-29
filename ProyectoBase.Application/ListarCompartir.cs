using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ListarCompartir
    {
        Data.ListarCompartir _ListarCompartir = new Data.ListarCompartir();

        public List<Models.ListarCompartir> SP_ListarCompartir(Models.ListarCompartir listarCompartir)
        {
            return _ListarCompartir.SP_ListarCompartir(listarCompartir);
        }
    }
}
