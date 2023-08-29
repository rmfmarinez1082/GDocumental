using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ListarDocumento
    {
        ManejoDatos b = new ManejoDatos();

        //SP MOSTRAR USUARIOS POR ID DE EMPRESA
        public List<Models.LisUser> SP_LisUser(Models.LisUser lisUser)
        {
            b.ExecuteCommandSP("SP_LisUser");
            b.AddParameter("@Id", lisUser.IdEntidad, SqlDbType.VarChar);
            b.AddParameter("@Iduser", lisUser.Id, SqlDbType.VarChar);

            List<Models.LisUser> resultado = new List<Models.LisUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.LisUser item = new Models.LisUser()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    EMail = reader["EMail"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        //SP MOSTRAR USUARIOS POR ID DE DEPARTAMENTO y EMPRESA
        public List<Models.LisUser> SP_LisUserDepEmp(Models.LisUser LisUserDepEmp)
        {
            b.ExecuteCommandSP("SP_LisUserDepEmp");
            b.AddParameter("@IdEmp", LisUserDepEmp.Id, SqlDbType.VarChar);
            b.AddParameter("@IdDep", LisUserDepEmp.IdDep, SqlDbType.VarChar);
            List<Models.LisUser> resultado = new List<Models.LisUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.LisUser item = new Models.LisUser()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    EMail = reader["EMail"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        //SP MOSTRAR DATOS DE UN USUARIO POR ID DE PERSONA
        public List<Models.LisUser> SP_LisUserper(Models.LisUser LisUserper)
        {
            b.ExecuteCommandSP("SP_LisUserper");
            b.AddParameter("@IdPer", LisUserper.IdPer, SqlDbType.VarChar);


            List <Models.LisUser> resultado = new List<Models.LisUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.LisUser item = new Models.LisUser()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    EMail = reader["EMail"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        //SP MOSTRAR DATOS 
        public List<Models.LisUser> SP_ListUserEntidad(Models.LisUser ListUserEntidad)
        {
            b.ExecuteCommandSP("SP_ListUserEntidad");
            b.AddParameter("@IdEntidad", ListUserEntidad.IdEntidad, SqlDbType.VarChar);
            b.AddParameter("@IdAsignacion", ListUserEntidad.IdAsignacion, SqlDbType.VarChar);
            b.AddParameter("@Iduser", ListUserEntidad.Id, SqlDbType.VarChar);

            List<Models.LisUser> resultado = new List<Models.LisUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.LisUser item = new Models.LisUser()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    EMail = reader["EMail"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.LisUser> SP_UserExpirado()
        {
            b.ExecuteCommandSP("SP_UserExpirado");

            List<Models.LisUser> resultado = new List<Models.LisUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.LisUser item = new Models.LisUser()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Documento = reader["Documento"].ToString(),
                    EMail = reader["EMail"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }




        public List<Models.LisUser> ListadoUsuariosGral()
        {
            b.ExecuteCommandSP("ListadoUsuariosGral");


            List<Models.LisUser> resultado = new List<Models.LisUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.LisUser item = new Models.LisUser()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    EMail = reader["EMail"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.LisUser Resetearpassword(Models.LisUser Usuario)

        {
            b.ExecuteCommandSP("Resetearpassword");
            b.AddParameter("@Id", Usuario.Id, SqlDbType.Int);
   


            Models.LisUser resultado = new Models.LisUser();
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
