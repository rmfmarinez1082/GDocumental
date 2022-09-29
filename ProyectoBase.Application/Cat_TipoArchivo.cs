using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_TipoArchivo
    {
        Data.Cat_TipoArchivo _cat_TipoArchivo = new Data.Cat_TipoArchivo();
        public List<Models.Cat_TipoArchivo> Cat_TipoArchivo_Listar()
        {
            return _cat_TipoArchivo.Cat_TipoArchivo_Listar();
        }
    }
}
