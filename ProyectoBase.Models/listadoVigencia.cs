using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class listadoVigencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DiasRestantes { get; set; }

        public string FechaVencimiento { get; set; }
    }
}
