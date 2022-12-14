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

        public Models.Cat_ClasificacionArchivo SP_RESSET()
        {
            return _cat_ClasificacionArchivo.SP_RESSET();
        }
        public List<Models.Cat_ClasificacionArchivo> Cat_ClasificacionArchivo_Listar()
        {
            return _cat_ClasificacionArchivo.Cat_ClasificacionArchivo_Listar();
        }
        public List<Models.Cat_ClasificacionArchivo> RUTA()
        {
            return _cat_ClasificacionArchivo.RUTA();
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

        public Models.Cat_ClasificacionArchivo SP_AgregarClasArch(Models.Cat_ClasificacionArchivo nuevaclas)
        {
            return _cat_ClasificacionArchivo.SP_AgregarClasArch(nuevaclas);
        }

        public Models.Cat_ClasificacionArchivo SP_AgregarSubClasArch(Models.Cat_ClasificacionArchivo nuevasubclas)
        {
            return _cat_ClasificacionArchivo.SP_AgregarSubClasArch(nuevasubclas);
        }
        public Models.Cat_ClasificacionArchivo SP_DelClas(Models.Cat_ClasificacionArchivo carpeta)
        {
            return _cat_ClasificacionArchivo.SP_DelClas(carpeta);
        } 
        public Models.Cat_ClasificacionArchivo SP_Renombrar(Models.Cat_ClasificacionArchivo carpeta)
        {
            return _cat_ClasificacionArchivo.SP_Renombrar(carpeta);
        }

        public List<Models.Cat_ClasificacionArchivo> SP_DocPadre(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
            return _cat_ClasificacionArchivo.SP_DocPadre(cat_ClasificacionArchivo);
        }
        public List<Models.Cat_ClasificacionArchivo> SP_DocPadreCustodia(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
            return _cat_ClasificacionArchivo.SP_DocPadreCustodia(cat_ClasificacionArchivo);
        }

        //CUSTODIAS


        public List<Models.Cat_ClasificacionArchivo> cat_DocumentosCustodia()
        {
            return _cat_ClasificacionArchivo.cat_DocumentosCustodia();
        }

        public List<Models.Cat_ClasificacionArchivo> cat_DocumentosSubCustodia(Models.Cat_ClasificacionArchivo cat_ClasificacionDoc)
        {
            return _cat_ClasificacionArchivo.cat_DocumentosSubCustodia(cat_ClasificacionDoc);
        }

    }


}
