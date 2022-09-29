using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Documentos
    {
        Data.Documentos _Documentos = new Data.Documentos();

        public Models.Documento Documento_Agregar(Models.NuevoDocumento nuevoDocumento)
        {
            return _Documentos.Documento_Agregar(nuevoDocumento);
        } 
        public Models.Documento Documento_AgregarPDF(Models.NuevoDocumento nuevoDocumento)
        {
            return _Documentos.Documento_AgregarPDF(nuevoDocumento);
        }

        public Models.Documento SP_ListarDocumento(Models.Documento documento)
        {
            return _Documentos.SP_ListarDocumento(documento);
        }


        public Models.Documento SP_DocumentoInfo(Models.Documento doc)
        {
            return _Documentos.SP_DocumentoInfo(doc);
        }

        public Models.Documento SP_DocumentoInfo2(Models.Documento doc2)
        {
            return _Documentos.SP_DocumentoInfo2(doc2);
        }

        public Models.Documento SP_QuitarArchivo(Models.Documento Ddoc)
        {
            return _Documentos.SP_QuitarArchivo(Ddoc);
        }
        public Models.Documento SP_DocumentoActualizar(Models.Documento Adoc)
        {
            return _Documentos.SP_DocumentoActualizar(Adoc);
        }
    }
}
