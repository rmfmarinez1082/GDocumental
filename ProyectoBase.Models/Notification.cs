using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Notification
    {
        public int IdUsuario { get; set; }
        public int Id { get; set; }
        public int Ids { get; set; }
        public int IdDocumento { get; set; }
        public string Nombre { get; set; }
        public string NombreEmisor { get; set; }
        public string Documento { get; set; }
        public string NmArchivo { get; set; }
        public int IdAdmin { get; set; }
        public string fecha { get; set; }
        public int Tnoti { get; set; }

    }
}
