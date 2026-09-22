using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class LisUser
    {
        public int Id { get; set; }
        public int IdDoc { get; set; }

        public int IdAdmin { get; set; }
        public string Nombre { get; set; }
        public string EMail { get; set; }
        public string Documento { get; set; }

        public int IdDep { get; set; }
        public int IdPer { get; set; }
        public int IdEntidad { get; set; }
        public int IdAsignacion { get; set; }


       
    }
}
