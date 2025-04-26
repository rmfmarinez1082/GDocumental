using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Img
    {
        public int Id { get; set; }      
        public int IdDoc { get; set; }      
        public string NmArchivo { get; set; }      // nombre encriptado o único
        public string NmOriginal { get; set; }     // nombre original
        public string Extension { get; set; }      // tipo .jpg, .png, etc.
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public string RutaCompleta { get; set; }
    }
}
