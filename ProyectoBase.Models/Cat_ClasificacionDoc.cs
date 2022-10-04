using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Cat_ClasificacionDoc
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Publica { get; set; }
        public string Interno { get; set; }
        public string Restringida { get; set; }
        public string Confidencial { get; set; }


    }
}
