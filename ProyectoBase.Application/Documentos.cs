using ProyectoBase.Models;
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
        public Models.Documento SP_ActualizarDoc(Models.NuevoDocumento nuevoDocumento)
        {
            return _Documentos.SP_ActualizarDoc(nuevoDocumento);
        }
        public Models.Documento SP_ActualizarDocPDF(Models.NuevoDocumento nuevoDocumento)
        {
            return _Documentos.SP_ActualizarDocPDF(nuevoDocumento);
        }
        public Models.Documento Documento_custodiaA(Models.NuevoDocumento nuevoDocumento)
        {
            return _Documentos.Documento_custodiaA(nuevoDocumento);
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
        public Models.Documento sp_NombreRutaDoc(Models.Documento doc)
        {
            return _Documentos.sp_NombreRutaDoc(doc);
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

        public List<Models.Documento> SP_INF_Prestado(Models.Documento documento)
        {
            return _Documentos.SP_INF_Prestado(documento);
        }

        public List<Models.Documento> CheckDocPrestado()
        {
            return _Documentos.CheckDocPrestado();
        }
        public Models.Documento SP_NPrestar(Models.Documento Ddoc)
        {
            return _Documentos.SP_NPrestar(Ddoc);
        }

        public Models.Documento DocumentoInsertarPermiso(Models.Documento Doc)
        {
            return _Documentos.DocumentoInsertarPermiso(Doc);
        } 
        public Models.Documento HabilitarPermisos(Models.Documento Doc)
        {
            return _Documentos.HabilitarPermisos(Doc);
        }
    }
}
