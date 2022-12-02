using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class NuevoDocumento
    {
        public string Nombre {get; set;}
        public string Version { get; set;}
        public int IdTipoDocumento { get; set;}
        public int Id { get; set;}
        public string PalabraClave { get; set; }
        public string Descripcion { get; set; }

        public string FechaRevision { get; set; }
        public string Fechadeentradaenvigor { get; set; }
        public string FechaPublicacion { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaProximaRevision { get; set; }

        public int IdTipoArchivo { get; set; }
        public int IdMedioAlmacenamiento { get; set; }
        public int checkboxBD { get; set; }
        public int checkboxCorreo { get; set; }


        public int IdClasificacion { get; set; }
        public int IdClasificacionArchivo { get; set; }
        public int IdSubClasificacionArchivo { get; set; }
        public string Idtemporal { get; set; }

        public int IdNombre3 { get; set; }

        public string NmArchivo { get; set; }
        public string NmArchivoword { get; set; }
        public string NmOriginal { get; set; }
        public int IdUsuario { get; set; }

    }
}
