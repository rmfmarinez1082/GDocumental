using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_ClasificacionArchivo
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Cat_ClasificacionArchivo SP_RESSET()
        {
            b.ExecuteCommandSP("SP_RESSET");
            Models.Cat_ClasificacionArchivo resultado = new Models.Cat_ClasificacionArchivo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_ClasificacionArchivo> Cat_ClasificacionArchivo_Listar()
        {
            b.ExecuteCommandSP("Cat_ClasificacionArchivo_Listar");
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
        public List<Models.Cat_ClasificacionArchivo> SP_Subclas()
        {
            b.ExecuteCommandSP("SP_Subclas");
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
        public List<Models.Cat_ClasificacionArchivo> Cat_SubClasificacionArchivo_Listar(Models.Cat_ClasificacionArchivo  cat_ClasificacionArchivo)
        {
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



        public Models.Cat_ClasificacionArchivo Cat_ClasificacionArchivo_Seleccionar(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
            b.ExecuteCommandSP("Cat_ClasificacionArchivo_Seleccionar");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);

            Models.Cat_ClasificacionArchivo resultado = new Models.Cat_ClasificacionArchivo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.NombreClasificacion = reader["Clasificacion"].ToString();
                resultado.NombreSubcalsificacion = reader["Subclasificacion"].ToString();
                resultado.Nombre3 = reader["Clasificacion3"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_ClasificacionArchivo SP_AgregarClasArch(Models.Cat_ClasificacionArchivo nuevaclas)
        {
            b.ExecuteCommandSP("SP_AgregarClasArch");
            b.AddParameter("@Nombre", nuevaclas.Nombre, SqlDbType.VarChar);
            Models.Cat_ClasificacionArchivo resultado = new Models.Cat_ClasificacionArchivo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_ClasificacionArchivo SP_AgregarSubClasArch(Models.Cat_ClasificacionArchivo nuevasubclas)
        
        {
            b.ExecuteCommandSP("SP_AgregarSubClasArch");
            b.AddParameter("@Nombre", nuevasubclas.Nombre, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", nuevasubclas.Idpadre, SqlDbType.VarChar); 
            b.AddParameter("@Id", nuevasubclas.Idtemporal, SqlDbType.VarChar);

            Models.Cat_ClasificacionArchivo resultado = new Models.Cat_ClasificacionArchivo();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_ClasificacionArchivo> RUTA()
        {
            b.ExecuteCommandSP("RUTA");
            List<Models.Cat_ClasificacionArchivo> resultado = new List<Models.Cat_ClasificacionArchivo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ClasificacionArchivo item = new Models.Cat_ClasificacionArchivo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    nivel = Convert.ToInt32(reader["Nivel"].ToString()),
                    ruta = reader["RUTA"].ToString(),
                    Idpadre = Convert.ToInt32(reader["Idpadre"].ToString())

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.Cat_ClasificacionArchivo> SP_DocPadre(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
       

            b.ExecuteCommandSP("SP_DocPadre");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);
            List<Models.Cat_ClasificacionArchivo> resultado = new List<Models.Cat_ClasificacionArchivo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ClasificacionArchivo item = new Models.Cat_ClasificacionArchivo()
                {
                    Nombre = reader["Nombre"].ToString(),
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    IdDoc = Convert.ToInt32(reader["IdDoc"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
