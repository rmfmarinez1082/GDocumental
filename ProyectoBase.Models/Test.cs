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

        public static Models.Notification SP_EstadoPrestasmo(Models.Notification datos)
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("SP_EstadoPrestasmo");
            b.AddParameter("@IdSesion", datos.IdUsuario, SqlDbType.VarChar);
            b.AddParameter("@IdDoc", datos.IdDocumento, SqlDbType.VarChar);

            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Dias"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public static Models.Notification SP_StatusDoCompartido(Models.Notification datos)
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("SP_StatusDoCompartido");
            b.AddParameter("@IdDoc", datos.IdDocumento, SqlDbType.VarChar);

            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Ids = Convert.ToInt32(reader["Compartido"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        } 
        public static Models.Documento SP_ASKCOmpartido(Models.Documento datos)
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("SP_ASKCOmpartido");
            b.AddParameter("@IdDoc", datos.Id, SqlDbType.VarChar);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Id = Convert.ToInt32(reader["Result"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public static Models.Notification sp_NombreRutaDoc(Models.Notification datos)
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("sp_NombreRutaDoc");
            b.AddParameter("@IdDoc", datos.IdDocumento, SqlDbType.VarChar);

            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Nombre = reader["Nombre"].ToString();

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public static Models.Notification ValidacionPermiso(Models.Notification datos)
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("ValidacionPermiso");
            b.AddParameter("@IdDoc", datos.IdDocumento, SqlDbType.VarChar);
            b.AddParameter("@IdUSer", datos.IdUsuario, SqlDbType.VarChar);

            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public static Models.Notification Editor(Models.Notification datos)
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("Editor");
            b.AddParameter("@IdDoc", datos.IdDocumento, SqlDbType.VarChar);
          

            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Nombre = reader["Nombre"].ToString();

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public static Models.Notification VerificarEditable(Models.Notification datos)
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("VerificarEditable");
            b.AddParameter("@IdDoc", datos.IdDocumento, SqlDbType.VarChar);
            b.AddParameter("@IdUSer", datos.IdUsuario, SqlDbType.VarChar);

            Models.Notification resultado = new Models.Notification();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public static Models.Sistema RutaEncriptado()
        {
            AccesoDatos b = new AccesoDatos();
            b.ExecuteCommandSP("RutaEncriptado");

            Models.Sistema resultado = new Models.Sistema();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.initVector = reader["initVector"].ToString();
                resultado.passPhrase = reader["passPhrase"].ToString();
                resultado.textFileSalt = reader["textFileSalt"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
