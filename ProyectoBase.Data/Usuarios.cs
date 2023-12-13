using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Usuarios
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Usuarios Usuario_Selecionar_Pas_US(Models.Usuarios usuarios)
        {
            b.ExecuteCommandSP("Usuario_Selecionar_Pas_US");
            b.AddParameter("@Email", usuarios.Email, SqlDbType.VarChar);
            b.AddParameter("@Password", usuarios.Password, SqlDbType.VarChar);
            b.AddParameter("@Session", usuarios.Session, SqlDbType.Bit);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Apellidos = reader["Apellidos"].ToString();
                resultado.Email = reader["Correo"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                resultado.NombreRol = reader["NombreRol"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.Mensaje = reader["Mensaje"].ToString();
                resultado.ClaveCoo = reader["ClaveCoo"].ToString();
                resultado.Inicial = reader["Inicial"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuarios coo_Session_Seleccionar(string Clave)
        {
            b.ExecuteCommandSP("coo_Session_Seleccionar");
            b.AddParameter("@Clave", Clave, SqlDbType.VarChar);

            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.Apellidos = reader["Apellidos"].ToString();
                resultado.Email = reader["Correo"].ToString();
                resultado.IdRol = Convert.ToInt32(reader["IdRol"].ToString());
                resultado.NombreRol = reader["NombreRol"].ToString();
                resultado.RutaAcceso = reader["RutaAcceso"].ToString();
                resultado.Mensaje = reader["Mensaje"].ToString();
                resultado.ClaveCoo = reader["ClaveCoo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Usuarios> Usuarios_Listar()
        {
            b.ExecuteCommandSP("Usuarios_Listar");
            List<Models.Usuarios> resultado = new List<Models.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Usuarios item = new Models.Usuarios()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Apellidos = reader["Apellidos"].ToString(),
                    Email = reader["Correo"].ToString(),
                    NombreRol = reader["NombreRol"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }  
        
        public List<Models.Usuarios> SP_ConteoUsuarios()
        {
            b.ExecuteCommandSP("SP_ConteoUsuarios");
            List<Models.Usuarios> resultado = new List<Models.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Usuarios item = new Models.Usuarios()
                {
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        } 
        public List<Models.Usuarios> SP_ConteoUsuariosActivos()
        {
            b.ExecuteCommandSP("SP_ConteoUsuariosActivos");
            List<Models.Usuarios> resultado = new List<Models.Usuarios>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Usuarios item = new Models.Usuarios()
                {
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Usuarios SP_RegistrarUser(Models.Usuarios Nusuario)
        {
            b.ExecuteCommandSP("SP_RegistrarUser");
            b.AddParameter("@Puesto", Nusuario.IdPuesto, SqlDbType.Int);
            b.AddParameter("@Nombre", Nusuario.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoP", Nusuario.Apellidos, SqlDbType.NVarChar);
            b.AddParameter("@ApellidoM", Nusuario.ApellidoM, SqlDbType.NVarChar);
            b.AddParameter("@Correo", Nusuario.Email, SqlDbType.NVarChar);
            b.AddParameter("@Contraseña", Nusuario.Password, SqlDbType.NVarChar);
            b.AddParameter("@Rol", Nusuario.IdRol, SqlDbType.Int);
            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        } 
        public Models.Usuarios SP_ActualizarUsuario(Models.Usuarios usuario)
        {
            b.ExecuteCommandSP("SP_ActualizarUsuario");
            b.AddParameter("@Id", usuario.Id, SqlDbType.Int);
            b.AddParameter("@Contraseña", usuario.Password, SqlDbType.NVarChar);
            Models.Usuarios resultado = new Models.Usuarios();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
