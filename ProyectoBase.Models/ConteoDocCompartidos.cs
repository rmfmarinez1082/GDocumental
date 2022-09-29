using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class ConteoDocCompartidos
    {
        public int Id { get; set; }
        public string compartidos { get; set; }
        public string TotalDocVigente { get; set; }
        public string TotalDocVencido { get; set; }
    }
}
