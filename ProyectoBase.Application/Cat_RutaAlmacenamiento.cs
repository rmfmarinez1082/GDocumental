using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_RutaAlmacenamiento
    {
        Data.Cat_RutaAlmacenamiento _cat_RutaAlmacenamiento = new Data.Cat_RutaAlmacenamiento();

        public Models.Cat_RutaAlmacenamiento Cat_RutaAlmacenamiento_Seleccionar()
        {
            return _cat_RutaAlmacenamiento.Cat_RutaAlmacenamiento_Seleccionar();
        }
        //public Models.Cat_RutaAlmacenamiento Cat_RutaAlmacenamiento_temporal()
        //{
        //    return _cat_RutaAlmacenamiento.Cat_RutaAlmacenamiento_temporal();
        //}
    }
}
