using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Cat_ClasificacionArchivo
    {
        public int Id { get; set; }
        public int IdDoc { get; set; }
        public int Idhijo { get; set; }
        public int IdTres { get; set; }
        public int IdUser { get; set; }
        public string Nombre { get; set; }
        public string Idtemporal { get; set; }

        public string NombreClasificacion { get; set; }
        public string NombreSubcalsificacion { get; set; }
        public string Nombre3 { get; set; } 
        
        public string ruta { get; set; }
        public int nivel { get; set; }
        public string Idpadre { get; set; }


    }
}
