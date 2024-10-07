using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class List_Doc
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.List_Doc> SP_ListarDocumentos(Models.List_Doc listarDoc)
        {
            b.ExecuteCommandSP("SP_ListarDocumentos");
            b.AddParameter("@IdSesion", listarDoc.IdSesion, SqlDbType.VarChar);

            List<Models.List_Doc> resultado = new List<Models.List_Doc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.List_Doc item = new Models.List_Doc()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    IdTipoArchivo = Convert.ToInt32(reader["Custodia"].ToString()),
                    IdMedioAlmacenamiento = Convert.ToInt32(reader["Prestamo"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Version = reader["Version"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    FechaEntradaVigor = reader["FechaEntradaVigor"].ToString(),
                    PalabrasClave = reader["PalabrasClave"].ToString(), 
                    NmArchivo = reader["NmArchivoword"].ToString(),

                    NmOriginal= reader["NmArchivo"].ToString(),

                    ///BLOQUEO
                    IdClasificacionArchivo = Convert.ToInt32(reader["T_Doc"].ToString())


                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.List_Doc> SP_ListarDocumentosCustodia(Models.List_Doc listarDoc)
        {
            b.ExecuteCommandSP("SP_ListarDocumentosCustodia");
            b.AddParameter("@IdSesion", listarDoc.IdSesion, SqlDbType.VarChar);

            List<Models.List_Doc> resultado = new List<Models.List_Doc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.List_Doc item = new Models.List_Doc()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Version = reader["Version"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    FechaEntradaVigor = reader["FechaEntradaVigor"].ToString(),
                    PalabrasClave = reader["PalabrasClave"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        } 
        public List<Models.List_Doc> SP_RegistroDelete()
        {
            b.ExecuteCommandSP("SP_RegistroDelete");

            List<Models.List_Doc> resultado = new List<Models.List_Doc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.List_Doc item = new Models.List_Doc()
                {
                    Nombre = reader["Documento"].ToString(),
                    NombreUsuario = reader["Nombre"].ToString(),
                    FechaEntradaVigor = reader["Fecha"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.List_Doc> SP_SeleccionarPorId(Models.List_Doc list_DocID)
        {
            b.ExecuteCommandSP("SP_SeleccionarPorId");
            b.AddParameter("@Id", list_DocID.Id, SqlDbType.VarChar);
            List<Models.List_Doc> resultado = new List<Models.List_Doc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.List_Doc item = new Models.List_Doc()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Version = reader["Version"].ToString(),
                    NmArchivo = reader["NmArchivo"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    Registrado = reader["Registrado"].ToString(),
                    FechaVigor = reader["FechaVigor"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    Clasificacion = reader["Clasificacion"].ToString(),
                    TipoDocumento = reader["TipoDocumento"].ToString(),
                    editable = reader["editable"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.List_Doc> DetalleDocCompartido(Models.List_Doc listarDoc)
        {
            b.ExecuteCommandSP("DetalleDocCompartido");
            b.AddParameter("@IdAdmin", listarDoc.IdSesion, SqlDbType.VarChar);
            b.AddParameter("@IdDoc", listarDoc.Id, SqlDbType.VarChar);

            List<Models.List_Doc> resultado = new List<Models.List_Doc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.List_Doc item = new Models.List_Doc()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    FechaEntradaVigor = reader["FechaCompartido"].ToString(),
                    Estatus = reader["Estatus"].ToString(),
                    IdClasificacionArchivo = Convert.ToInt32(reader["IdDocumento"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.List_Doc> SP_ListarDocAdmin()
        {
            b.ExecuteCommandSP("SP_ListarDocAdmin");

            List<Models.List_Doc> resultado = new List<Models.List_Doc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.List_Doc item = new Models.List_Doc()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    NombreUsuario = reader["Usuario"].ToString(),
                    Clasificacion = reader["Clasificacion"].ToString(),
                    PalabrasClave = reader["PalabrasClave"].ToString(),

                    NmArchivo = reader["NmArchivo"].ToString(),

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public List<Models.List_Doc> DetalleDocCompartidoAdmin(Models.List_Doc list_Doc)
        {
            b.ExecuteCommandSP("DetalleDocCompartidoAdmin");
            b.AddParameter("@IdDoc", list_Doc.Id, SqlDbType.VarChar);

            List<Models.List_Doc> resultado = new List<Models.List_Doc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.List_Doc item = new Models.List_Doc()
                {
                    //Id = Convert.ToInt32(reader["Id"].ToString()),
                    Nombre = reader["Doc"].ToString(),
                    NombreUsuario = reader["Nombre"].ToString(),
                    FechaEntradaVigor = reader["FechaCompartido"].ToString(),
                    Estatus = reader["Estatus"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
