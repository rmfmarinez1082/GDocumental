using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Documentos
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Documento Documento_Agregar(Models.NuevoDocumento nuevoDocumento)

        {
            b.ExecuteCommandSP("Documento_Agregar");
            b.AddParameter("@Nombre", nuevoDocumento.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@Version", nuevoDocumento.Version, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoDocumento", nuevoDocumento.IdTipoDocumento, SqlDbType.Int);
            b.AddParameter("@PalabraClave", nuevoDocumento.PalabraClave, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", nuevoDocumento.Descripcion, SqlDbType.NVarChar);

            b.AddParameter("@FechaRevision", nuevoDocumento.FechaRevision, SqlDbType.NVarChar);
            b.AddParameter("@Fechadeentradaenvigor", nuevoDocumento.Fechadeentradaenvigor, SqlDbType.NVarChar);
            b.AddParameter("@FechaPublicacion", nuevoDocumento.FechaPublicacion, SqlDbType.NVarChar);
            b.AddParameter("@FechaVencimiento", nuevoDocumento.FechaVencimiento, SqlDbType.NVarChar);
            b.AddParameter("@FechaProximaRevision", nuevoDocumento.FechaProximaRevision, SqlDbType.NVarChar);
            
            b.AddParameter("@IdTipoArchivo", nuevoDocumento.IdTipoArchivo, SqlDbType.Int);
            b.AddParameter("@IdMedioAlmacenamiento", nuevoDocumento.IdMedioAlmacenamiento, SqlDbType.Int);
            b.AddParameter("@checkboxBD", nuevoDocumento.checkboxBD, SqlDbType.Int);
            b.AddParameter("@checkboxCorreo", nuevoDocumento.checkboxCorreo, SqlDbType.Int);

            b.AddParameter("@IdClasificacion", nuevoDocumento.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@IdClasificacionArchivo", nuevoDocumento.IdClasificacionArchivo, SqlDbType.Int);
            b.AddParameter("@IdSubClasificacionArchivo", nuevoDocumento.IdSubClasificacionArchivo, SqlDbType.Int);
            b.AddParameter("@IdNombre3", nuevoDocumento.IdNombre3, SqlDbType.Int);

            b.AddParameter("@NmArchivo", nuevoDocumento.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmArchivoword", nuevoDocumento.NmArchivoword, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", nuevoDocumento.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@IdUsuario", nuevoDocumento.IdUsuario, SqlDbType.Int);




            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
               
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        } 
        public Models.Documento Documento_AgregarPDF(Models.NuevoDocumento nuevoDocumento)
        {
            b.ExecuteCommandSP("Documento_AgregarPDF");
            b.AddParameter("@Nombre", nuevoDocumento.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@Version", nuevoDocumento.Version, SqlDbType.NVarChar);
            b.AddParameter("@IdTipoDocumento", nuevoDocumento.IdTipoDocumento, SqlDbType.Int);
            b.AddParameter("@PalabraClave", nuevoDocumento.PalabraClave, SqlDbType.NVarChar);
            b.AddParameter("@Descripcion", nuevoDocumento.Descripcion, SqlDbType.NVarChar);

            b.AddParameter("@FechaRevision", nuevoDocumento.FechaRevision, SqlDbType.NVarChar);
            b.AddParameter("@Fechadeentradaenvigor", nuevoDocumento.Fechadeentradaenvigor, SqlDbType.NVarChar);
            b.AddParameter("@FechaPublicacion", nuevoDocumento.FechaPublicacion, SqlDbType.NVarChar);
            b.AddParameter("@FechaVencimiento", nuevoDocumento.FechaVencimiento, SqlDbType.NVarChar);
            b.AddParameter("@FechaProximaRevision", nuevoDocumento.FechaProximaRevision, SqlDbType.NVarChar);
            
            b.AddParameter("@IdTipoArchivo", nuevoDocumento.IdTipoArchivo, SqlDbType.Int);
            b.AddParameter("@IdMedioAlmacenamiento", nuevoDocumento.IdMedioAlmacenamiento, SqlDbType.Int);
            b.AddParameter("@checkboxBD", nuevoDocumento.checkboxBD, SqlDbType.Int);
            b.AddParameter("@checkboxCorreo", nuevoDocumento.checkboxCorreo, SqlDbType.Int);

            b.AddParameter("@IdClasificacion", nuevoDocumento.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@IdClasificacionArchivo", nuevoDocumento.IdClasificacionArchivo, SqlDbType.Int);
            b.AddParameter("@IdSubClasificacionArchivo", nuevoDocumento.IdSubClasificacionArchivo, SqlDbType.Int);
            b.AddParameter("@IdNombre3", nuevoDocumento.IdNombre3, SqlDbType.Int);

            b.AddParameter("@NmArchivo", nuevoDocumento.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NmOriginal", nuevoDocumento.NmOriginal, SqlDbType.NVarChar);
            b.AddParameter("@IdUsuario", nuevoDocumento.IdUsuario, SqlDbType.Int);




            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
               
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Documento SP_ListarDocumento(Models.Documento documento)
        {
            b.ExecuteCommandSP("SP_ListarDocumento");
            b.AddParameter("@IdDoc", documento.Id, SqlDbType.Int);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.FechaEntradaVigor = reader["FechaEntradaVigor"].ToString();
                resultado.Version = reader["Version"].ToString();
                resultado.Descripcion = reader["Descripcion"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Documento SP_DocumentoInfo(Models.Documento doc)
        {
            b.ExecuteCommandSP("SP_DocumentoInfo");
            b.AddParameter("@IdDocumento ", doc.Id, SqlDbType.Int);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();
                resultado.FechaEntradaVigor = reader["FechaEntradaVigor"].ToString();
                resultado.Version = reader["Version"].ToString();
                resultado.Descripcion = reader["Descripcion"].ToString();
                resultado.NmArchivo = reader["NmArchivo"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        
        public Models.Documento SP_DocumentoInfo2(Models.Documento doc2)
        {
            b.ExecuteCommandSP("SP_DocumentoInfo2");
            b.AddParameter("@Id", doc2.Id, SqlDbType.Int);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Nombre = reader["Nombre"].ToString();


                resultado.FechaEntradaVigor = reader["FechaVigor"].ToString();
                resultado.FechaRevision = reader["FechaRevision"].ToString();
                resultado.FechaPublicacion = reader["FechaPublicacion"].ToString();
                resultado.FechaVencimiento = reader["FechaVencimiento"].ToString();
                resultado.FechaProximaRevision = reader["FechaProximaRevision"].ToString();



                resultado.Version = reader["Version"].ToString();
                resultado.Descripcion = reader["Descripcion"].ToString();
                resultado.NmArchivo = reader["NmArchivo"].ToString();
                resultado.PalabraClave = reader["PalabrasClave"].ToString();
              

                resultado.TipoDocumento = reader["TipoDocumento"].ToString();
                resultado.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"].ToString());
                resultado.IdTipoArchivo = Convert.ToInt32(reader["IdTipoArchivo"].ToString());
                resultado.IdMedioAlmacenamiento = Convert.ToInt32(reader["IdMedioAlmacenamiento"].ToString());
                resultado.IdClasificacion = Convert.ToInt32(reader["IdClasificacion"].ToString());
                resultado.IdClasificacionArchivo = Convert.ToInt32(reader["IdClasificacionArchivo"].ToString());
                resultado.IdSubclasificacionArchivo = Convert.ToInt32(reader["IdSubClasificacionArchivo"].ToString());
                resultado.IdNombre3 = Convert.ToInt32(reader["IdNombre3"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Documento SP_QuitarArchivo(Models.Documento Ddoc)
        {
            
            b.ExecuteCommandSP("SP_QuitarArchivo");
            b.AddParameter("@id", Ddoc.Id, SqlDbType.Int);
            b.AddParameter("@IdUser", Ddoc.IdUsuario, SqlDbType.Int);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Models.Documento SP_DocumentoActualizar(Models.Documento Adoc)
        {
            b.ExecuteCommandSP("SP_DocumentoActualizar");
            b.AddParameter("@id", Adoc.Id, SqlDbType.Int);
            b.AddParameter("@Nombre", Adoc.Nombre, SqlDbType.NVarChar);
            b.AddParameter("@FechaRevision", Adoc.FechaRevision, SqlDbType.Date);
            b.AddParameter("@FechaEntradaVigor", Adoc.FechaEntradaVigor, SqlDbType.Date);
            b.AddParameter("@FechaPublicacion", Adoc.FechaPublicacion, SqlDbType.Date);
            b.AddParameter("@FechaVencimiento", Adoc.FechaVencimiento, SqlDbType.Date);
            b.AddParameter("@FechaProximaRevision", Adoc.FechaProximaRevision, SqlDbType.Date);
            b.AddParameter("@Descripcion", Adoc.Descripcion, SqlDbType.NVarChar);
            b.AddParameter("@Version", Adoc.Version, SqlDbType.NVarChar);
            b.AddParameter("@PalabraClave", Adoc.PalabraClave, SqlDbType.NVarChar);

            b.AddParameter("@IdTipoDocumento", Adoc.IdTipoDocumento, SqlDbType.Int);
            b.AddParameter("@IdTipoArchivo", Adoc.IdTipoArchivo, SqlDbType.Int);
            b.AddParameter("@IdMedioAlmacenamiento", Adoc.IdMedioAlmacenamiento, SqlDbType.Int);
            b.AddParameter("@IdClasificacion", Adoc.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@IdClasificacionArchivo", Adoc.IdClasificacionArchivo, SqlDbType.Int);
            b.AddParameter("@IdSubclasificacionArchivo", Adoc.IdSubclasificacionArchivo, SqlDbType.Int);
            b.AddParameter("@IdNombre3  ", Adoc.IdNombre3, SqlDbType.Int);
            Models.Documento resultado = new Models.Documento();
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
