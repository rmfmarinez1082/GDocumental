using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models
{
    public static class Test
    {
        public static List<Models.Cat_ClasificacionArchivo> SP_DocPadre(Models.Cat_ClasificacionArchivo  cat_ClasificacionArchivo)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("SP_DocPadre");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);
            List<Models.Cat_ClasificacionArchivo> resultado = new List<Models.Cat_ClasificacionArchivo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ClasificacionArchivo item = new Models.Cat_ClasificacionArchivo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public static List<Models.Cat_ClasificacionArchivo> SP_DocHijo(Models.Cat_ClasificacionArchivo  cat_ClasificacionArchivo)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("SP_DocHijo");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);
            b.AddParameter("@idHijo", cat_ClasificacionArchivo.Idhijo, SqlDbType.VarChar);
            List<Models.Cat_ClasificacionArchivo> resultado = new List<Models.Cat_ClasificacionArchivo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ClasificacionArchivo item = new Models.Cat_ClasificacionArchivo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public static List<Models.Cat_ClasificacionArchivo> SP_tres(Models.Cat_ClasificacionArchivo  cat_ClasificacionArchivo)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("SP_tres");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);
            b.AddParameter("@idHijo", cat_ClasificacionArchivo.Idhijo, SqlDbType.VarChar);
            b.AddParameter("@Nombre3", cat_ClasificacionArchivo.IdTres, SqlDbType.VarChar);
            List<Models.Cat_ClasificacionArchivo> resultado = new List<Models.Cat_ClasificacionArchivo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ClasificacionArchivo item = new Models.Cat_ClasificacionArchivo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public static List<Models.Cat_ClasificacionArchivo> Cat_SubClasificacionArchivo_listar(Models.Cat_ClasificacionArchivo  cat_ClasificacionArchivo)
        {
            AccesoDatos b = new AccesoDatos();

            b.ExecuteCommandSP("Cat_SubClasificacionArchivo_listar");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);
            List<Models.Cat_ClasificacionArchivo> resultado = new List<Models.Cat_ClasificacionArchivo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ClasificacionArchivo item = new Models.Cat_ClasificacionArchivo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



    }
}
