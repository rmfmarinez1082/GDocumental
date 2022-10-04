using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_ClasificacionDoc
    {
        Data.Cat_ClasificacionDoc _cat_ClasificacionDoc = new Data.Cat_ClasificacionDoc();
        public List<Models.Cat_ClasificacionDoc> Cat_ClasificacionDoc_Listar()
        {
            return _cat_ClasificacionDoc.Cat_ClasificacionDoc_Listar();
        }

        public Models.Cat_ClasificacionDoc SP_ConteoClasificacion()
        {
            return _cat_ClasificacionDoc.SP_ConteoClasificacion();
        }
    }
}
