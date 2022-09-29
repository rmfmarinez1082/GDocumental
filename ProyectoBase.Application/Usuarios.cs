using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Usuarios
    {
        Data.Usuarios _Usuario = new Data.Usuarios();

        public Models.Usuarios Iniciar(Models.Usuarios usuarios)
        {
            Models.Usuarios user = _Usuario.Usuario_Selecionar_Pas_US(usuarios);
            return user;
        }

        public Models.Usuarios coo_Session_Seleccionar(string clave)
        {
            Models.Usuarios usuario = _Usuario.coo_Session_Seleccionar(clave);
            return usuario;
        }
    }
}
