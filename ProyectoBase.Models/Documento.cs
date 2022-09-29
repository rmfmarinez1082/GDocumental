using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        public string PalabraClave { get; set; }
        public string Version { get; set; }
        public bool Vigencia { get; set; }
        public int IdClasificacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estatus { get; set; }
        public string Elaboro { get; set; }

        public int IdArchivo { get; set; }
        public string NmArchivo { get; set; }
        public string NmArchivoword { get; set; }
        public string NmOriginal { get; set; }
        public string DocumentoURL { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public string Descripcion { get; set; }

        public string FechaRevision { get; set; }
        public string FechaEntradaVigor { get; set; }
        public string FechaPublicacion { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaProximaRevision { get; set; }

        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public int IdTipoArchivo { get; set; }
        public int IdMedioAlmacenamiento { get; set; }
        public int IdClasificacionArchivo { get; set; }
        public int IdSubclasificacionArchivo { get; set; }
        public int IdNombre3 { get; set; }



    }
}
