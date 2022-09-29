using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_ClasificacionArchivo
    {
        Data.Cat_ClasificacionArchivo _cat_ClasificacionArchivo = new Data.Cat_ClasificacionArchivo();
        public List<Models.Cat_ClasificacionArchivo> Cat_ClasificacionArchivo_Listar()
        {
            return _cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Listar();
        }

        public List<Models.Cat_ClasificacionArchivo> SP_Subclas()
        {
            return _cat_ClasificacionArchivo.SP_Subclas();
        }
        public List<Models.Cat_ClasificacionArchivo> Cat_SubClasificacionArchivo_Listar(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            return _cat_ClasificacionArchivo.Cat_SubClasificacionArchivo_Listar(cat_ClasificacionDoc);
        }

        public Models.Cat_ClasificacionArchivo Cat_ClasificacionArchivo_Seleccionar(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
            return _cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Seleccionar(cat_ClasificacionArchivo);
        }

        public List<Models.Cat_ClasificacionArchivo> SP_AgregarClasArch(Models.Cat_ClasificacionArchivo nuevaclas)
        {
            return _cat_ClasificacionArchivo.SP_AgregarClasArch(nuevaclas);
        }

        public List<Models.Cat_ClasificacionArchivo> SP_AgregarSubClasArch(Models.Cat_ClasificacionArchivo nuevasubclas)
        {
            return _cat_ClasificacionArchivo.SP_AgregarSubClasArch(nuevasubclas);
        }
    }


}
