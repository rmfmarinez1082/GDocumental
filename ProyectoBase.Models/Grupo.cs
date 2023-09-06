using System;
using System.Collections.Generic;

namespace ProyectoBase.Models
{
	public class Grupo
	{
        public int Id { get; set; }
        public int IdP { get; set; }
        public string Nombre { get; set; }
        public string NombrePersona { get; set; }
        public string Empresa { get; set; }
        public string Fecha { get; set; }
        public string email { get; set; }
        public List<int> IdPlist { get; set; } // Cambio a List<int>
        public List<int> IdClist { get; set; }
    }
}

