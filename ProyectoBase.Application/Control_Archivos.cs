using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoBase.Application
{
    public class Control_Archivos
    {
        Data.Control_Archivos _Control_Archivos = new Data.Control_Archivos();

        public Models.Control_Archivos Control_Archivos_Id()
        {
            Models.Control_Archivos control_Archivos = _Control_Archivos.Control_Archivos_Id();
            return control_Archivos;
        }


        public Models.Documento NuevoArchivo(HttpPostedFile Archivo, string DirectorioUsuario, string DirectorioURL)
        {
            Models.Documento _Documento = new Models.Documento();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".pdf".Contains(FileExtension) ^ ".pdf".Contains(FileExtension) ^ ".pdf".Contains(FileExtension))
            {

                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo =NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');

                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + ".pdf");

                _Documento.IdArchivo = NuevoArchivo.Id;
                _Documento.NmArchivo = NombreArchivo + ".pdf";
                _Documento.NmOriginal = Archivo.FileName;
                _Documento.DocumentoURL = DirectorioURL + NombreArchivo + ".pdf";

            }

            return _Documento;
        }
        public Models.Documento NuevoArchivoword(HttpPostedFile Archivo, string DirectorioUsuario, string DirectorioURL)
        {
            Models.Documento _Documento = new Models.Documento();
            String FileExtension = Path.GetExtension(Archivo.FileName).ToLower();

            if (!Directory.Exists(DirectorioUsuario))
            {
                Directory.CreateDirectory(DirectorioUsuario);
            }

            if (".docx".Contains(FileExtension) ^ ".pptx".Contains(FileExtension) ^ ".xlsx".Contains(FileExtension) ^ ".dwg".Contains(FileExtension))
            {

                Models.Control_Archivos NuevoArchivo = Control_Archivos_Id();
                string NombreArchivo =NuevoArchivo.Clave + NuevoArchivo.Id.ToString().PadLeft(12, '0');

                //Archivo.SaveAs(DirectorioUsuario + NombreArchivo + ".docx");
                Archivo.SaveAs(DirectorioUsuario + NombreArchivo + FileExtension);

                //_Documento.IdArchivo = NuevoArchivo.Id;
                _Documento.NmArchivoword = NombreArchivo + FileExtension;
                //_Documento.NmOriginal = Archivo.FileName;
                //_Documento.DocumentoURL = DirectorioURL + NombreArchivo + ".docx";

            }

            return _Documento;
        }

    }
}
