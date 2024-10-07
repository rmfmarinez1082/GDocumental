using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class List_Doc
    {
        public int Id { get; set; }
        public int IdSesion { get; set; }
        public string NmArchivo { get; set; }
        public string NClaA { get; set; }
        public string Sub { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Descripcion { get; set; }
        public string PalabrasClave { get; set; }
        public string FechaEntradaVigor { get; set; } 
        public string FechaRegistro { get; set; } 
        public string FechaRevision { get; set; }
        public string FechaPublicacion { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaProximaRevision { get; set; }
        public string FechaVigor { get; set; }
        public string Registrado { get; set; } 
        public string Estatus { get; set; } 
        public string Clasificacion { get; set; } 
        public string TipoDocumento { get; set; }
        public int IdTipoArchivo { get; set; }
        public int IdMedioAlmacenamiento { get; set; }
        public int IdClasificacionArchivo { get; set; }

        public string NombreUsuario { get; set; }
        public string NmOriginal { get; set; }


        public string editable { get; set; }



    }
}
