using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ListarCompartir
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int prestamo { get; set; }
        
        public string Nombre { get; set; } 
        public string NombreWord { get; set; } 
        public string PalabrasClave { get; set; }
        public int IdTipoDocumento { get; set; }
        public string FechaEntradaVigor { get; set; }
        public string FechaVencimiento { get; set; }

        public int Editable { get; set; }
        public int Compartido { get; set; }
        public string NmOriginal { get; set; }
        public string Propietario { get; set; }

        public string Version { get; set; }

    }
}
