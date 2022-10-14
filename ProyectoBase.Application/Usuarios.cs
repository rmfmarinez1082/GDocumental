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

        public List<Models.Usuarios> SP_ConteoUsuarios()
        {
            return _Usuario.SP_ConteoUsuarios();
        }
        public List<Models.Usuarios> SP_ConteoUsuariosActivos()
        {
            return _Usuario.SP_ConteoUsuariosActivos();
        }

        public Models.Usuarios SP_RegistrarUser(Models.Usuarios Nusuario)
        { 
            return _Usuario.SP_RegistrarUser(Nusuario);
        }
        public Models.Usuarios SP_ActualizarUsuario(Models.Usuarios usuario)
        {
            return _Usuario.SP_ActualizarUsuario(usuario);
        }
    }
}
