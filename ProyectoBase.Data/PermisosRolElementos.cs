using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class PermisosRolElementos
    {
        ManejoDatos b = new ManejoDatos();

        //public List<Models.PermisosRolElementos> PermisosElementos(Models.Usuarios usuario)
        //{

        //    b.ExecuteCommandSP("PermisosElementos");
        //    b.AddParameter("@IdRol", usuario.IdRol, SqlDbType.VarChar);

        //    List <Models.PermisosRolElementos> resultado = new List<Models.PermisosRolElementos>();
        //    var reader = b.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Models.PermisosRolElementos item = new Models.PermisosRolElementos();
        //        {
        //            Activo = Convert.ToInt32(reader["Activo"].ToString());
        //            IdElemento = reader["IdElemento"].ToString();
        //        };


        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();
        //    return resultado;

        //}
        public List<Models.PermisosRolElementos> PermisosElementos(Models.Usuarios usuario)
        {
            b.ExecuteCommandSP("PermisosElementos");
            b.AddParameter("@IdRol", usuario.IdRol, SqlDbType.VarChar);
            List<Models.PermisosRolElementos> resultado = new List<Models.PermisosRolElementos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.PermisosRolElementos item = new Models.PermisosRolElementos()
                {
                    IdElemento = reader["IdElemento"].ToString(),
                    Activo = Convert.ToInt32(reader["Activo"].ToString()),
            
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;

        }

    }
}
