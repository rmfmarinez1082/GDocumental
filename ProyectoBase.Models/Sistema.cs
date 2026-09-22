using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public class Sistema
    {
        public string NombreSistema { get; set; }
        public string Acronimo { get; set; } 
        public string RutaLogo { get; set; }
        public string NombreEmpresa { get; set; }
        public string url_Imagen { get; set; }
        public string url_Sitio { get; set; }

        public int Versionamiento { get; set; }
        public string initVector { get; set; }

        public string passPhrase { get; set; }

        public string textFileSalt { get; set; }

    }
}
