using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBase.Models;

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
                //resultado.NombreSubcalsificacion = reader["Subclasificacion"].ToString();
                //resultado.Nombre3 = reader["Clasificacion3"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Cat_ClasificacionArchivo SP_AgregarClasArch(Models.Cat_ClasificacionArchivo nuevaclas)
        {
            b.ExecuteCommandSP("SP_AgregarClasArch");
            b.AddParameter("@Nombre", nuevaclas.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Idtemporal", nuevaclas.Idtemporal, SqlDbType.VarChar);

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
            b.AddParameter("@Idtemporal", nuevasubclas.Idtemporal, SqlDbType.VarChar);

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
        public Models.Cat_ClasificacionArchivo SP_DelClas(Models.Cat_ClasificacionArchivo carpeta)
        
        {
            b.ExecuteCommandSP("SP_DelClas");

            b.AddParameter("@Id", carpeta.Idtemporal, SqlDbType.VarChar);

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
        public Models.Cat_ClasificacionArchivo SP_Renombrar(Models.Cat_ClasificacionArchivo carpeta)
        
        {
            b.ExecuteCommandSP("SP_Renombrar");

            b.AddParameter("@Id", carpeta.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@Nombre", carpeta.Nombre, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", carpeta.Idpadre, SqlDbType.VarChar);
      

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
                    //Idpadre = Convert.ToInt32(reader["Idpadre"].ToString())

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
        public List<Models.Cat_ClasificacionArchivo> SP_DocPadreCustodia(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
       

            b.ExecuteCommandSP("SP_DocPadreCustodia");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);
            b.AddParameter("@Iduser", cat_ClasificacionArchivo.IdTres, SqlDbType.VarChar);
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
        public List<Models.Cat_ClasificacionArchivo> SP_DocCustodiaUbicacion(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo, Models.Documento documento)
        {

            b.ExecuteCommandSP("SP_DocCustodiaUbicacion");
            b.AddParameter("@Id", cat_ClasificacionArchivo.Id, SqlDbType.VarChar);
            b.AddParameter("@Iduser", cat_ClasificacionArchivo.IdTres, SqlDbType.VarChar); 
            b.AddParameter("@IdDoc", documento.Id, SqlDbType.VarChar);
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


        //CUSTODIAS
        public List<Models.Cat_ClasificacionArchivo> cat_DocumentosCustodia()
        {
            b.ExecuteCommandSP("cat_DocumentosCustodia");

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
        public List<Models.Cat_ClasificacionArchivo> cat_DocumentosSubCustodia(Models.Cat_ClasificacionArchivo cat_ClasificacionArchivo)
        {
            b.ExecuteCommandSP("cat_DocumentosSubCustodia");
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

        //OPERACIONES ARBOL CUSTODIAS
        public Models.Cat_ClasificacionArchivo SP_RESSET2()
        {
            b.ExecuteCommandSP("SP_RESSET2");
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

        public Models.Cat_ClasificacionArchivo SP_AgregarSubCarpeta(Models.Cat_ClasificacionArchivo nuevasubclas)

        {
            b.ExecuteCommandSP("SP_AgregarSubCarpeta");
            b.AddParameter("@Nombre", nuevasubclas.Nombre, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", nuevasubclas.Idpadre, SqlDbType.VarChar);
            b.AddParameter("@Idtemporal", nuevasubclas.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@IdUser", nuevasubclas.IdUser, SqlDbType.VarChar);

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
        public Models.Cat_ClasificacionArchivo RenombrarCarpeta(Models.Cat_ClasificacionArchivo carpeta)

        {
            b.ExecuteCommandSP("RenombrarCarpeta");

            b.AddParameter("@Id", carpeta.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@Nombre", carpeta.Nombre, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", carpeta.Idpadre, SqlDbType.VarChar);


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
        public Models.Cat_ClasificacionArchivo EliminarCarpetaC(Models.Cat_ClasificacionArchivo carpeta)

        {
            b.ExecuteCommandSP("EliminarCarpetaC");

            b.AddParameter("@Id", carpeta.Idtemporal, SqlDbType.VarChar);

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
        public Models.Cat_ClasificacionArchivo RegistrarCarpeta(Models.Cat_ClasificacionArchivo nuevaclas)
        {
            b.ExecuteCommandSP("RegistrarCarpeta");
            b.AddParameter("@Nombre", nuevaclas.Nombre, SqlDbType.VarChar);
            b.AddParameter("@Idtemporal", nuevaclas.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@IdUser", nuevaclas.IdUser, SqlDbType.VarChar);

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

        public Models.Cat_ClasificacionArchivo SP_DNDCustodia(Models.Cat_ClasificacionArchivo NdN)

        {
            b.ExecuteCommandSP("SP_DNDCustodia");

            b.AddParameter("@Idtemporal", NdN.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", NdN.Idpadre, SqlDbType.VarChar);


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
        public Models.Cat_ClasificacionArchivo SP_DNDocumentoCustodia(Models.Cat_ClasificacionArchivo NdN)

        {
            b.ExecuteCommandSP("SP_DNDocumentoCustodia");

            b.AddParameter("@Idtemporal", NdN.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", NdN.Idpadre, SqlDbType.VarChar);


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

        public Models.Cat_ClasificacionArchivo SP_DNDCarpetas(Models.Cat_ClasificacionArchivo NdN)

        {
            b.ExecuteCommandSP("SP_DNDCarpetas");

            b.AddParameter("@Idtemporal", NdN.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", NdN.Idpadre, SqlDbType.VarChar);


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

        public Models.Cat_ClasificacionArchivo SP_DNDocumento(Models.Cat_ClasificacionArchivo NdN)

        {
            b.ExecuteCommandSP("SP_DNDocumento");

            b.AddParameter("@Idtemporal", NdN.Idtemporal, SqlDbType.VarChar);
            b.AddParameter("@IdPadre", NdN.Idpadre, SqlDbType.VarChar);


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



        public List<Models.Cat_ClasificacionArchivo> Cat_ClasificacionArchivo_ListarPorIdUsuario(Models.Cat_ClasificacionArchivo carpeta)
        {
            b.ExecuteCommandSP("Cat_ClasificacionArchivo_ListarPorIdUsuario");
            b.AddParameter("@UserId", carpeta.Id, SqlDbType.Int);

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




        public List<Models.Cat_ClasificacionArchivo> Cat_SubClasificacionArchivo_ListarPorIdUsuario(Models.Cat_ClasificacionArchivo carpeta)
        {
            b.ExecuteCommandSP("Cat_SubClasificacionArchivo_ListarPorIdUsuario");
            b.AddParameter("@UserId", carpeta.IdUser, SqlDbType.Int);
            b.AddParameter("@IdPadre", carpeta.Id, SqlDbType.Int);


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
