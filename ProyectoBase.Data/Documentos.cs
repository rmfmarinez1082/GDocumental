using Newtonsoft.Json;
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

            b.AddParameter("@FechaRevision", nuevoDocumento.FechaRevision, SqlDbType.Date);
            b.AddParameter("@Fechadeentradaenvigor", nuevoDocumento.Fechadeentradaenvigor, SqlDbType.Date);
            b.AddParameter("@FechaPublicacion", nuevoDocumento.FechaPublicacion, SqlDbType.Date);
            b.AddParameter("@FechaVencimiento", nuevoDocumento.FechaVencimiento, SqlDbType.Date);
            b.AddParameter("@FechaProximaRevision", nuevoDocumento.FechaProximaRevision, SqlDbType.Date);
            
            b.AddParameter("@IdTipoArchivo", nuevoDocumento.IdTipoArchivo, SqlDbType.Int);
            b.AddParameter("@IdMedioAlmacenamiento", nuevoDocumento.IdMedioAlmacenamiento, SqlDbType.Int);
            b.AddParameter("@checkboxBD", nuevoDocumento.checkboxBD, SqlDbType.Int);
            b.AddParameter("@checkboxCorreo", nuevoDocumento.checkboxCorreo, SqlDbType.Int);
            b.AddParameter("@checkboxCustodia", nuevoDocumento.checkboxCustodia, SqlDbType.Int);

            b.AddParameter("@IdClasificacion", nuevoDocumento.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@Idtemporal", nuevoDocumento.Idtemporal, SqlDbType.VarChar);

          

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

            b.AddParameter("@FechaRevision", nuevoDocumento.FechaRevision, SqlDbType.Date);
            b.AddParameter("@Fechadeentradaenvigor", nuevoDocumento.Fechadeentradaenvigor, SqlDbType.Date);
            b.AddParameter("@FechaPublicacion", nuevoDocumento.FechaPublicacion, SqlDbType.Date);
            b.AddParameter("@FechaVencimiento", nuevoDocumento.FechaVencimiento, SqlDbType.Date);
            b.AddParameter("@FechaProximaRevision", nuevoDocumento.FechaProximaRevision, SqlDbType.Date);
            
            b.AddParameter("@IdTipoArchivo", nuevoDocumento.IdTipoArchivo, SqlDbType.Int);
            b.AddParameter("@IdMedioAlmacenamiento", nuevoDocumento.IdMedioAlmacenamiento, SqlDbType.Int);
            b.AddParameter("@checkboxBD", nuevoDocumento.checkboxBD, SqlDbType.Int);
            b.AddParameter("@checkboxCorreo", nuevoDocumento.checkboxCorreo, SqlDbType.Int);
            b.AddParameter("@checkboxCustodia", nuevoDocumento.checkboxCustodia, SqlDbType.Int);


            b.AddParameter("@IdClasificacion", nuevoDocumento.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@Idtemporal", nuevoDocumento.Idtemporal, SqlDbType.VarChar);

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

        public Models.Documento sp_NombreRutaDoc(Models.Documento doc)
        {
            b.ExecuteCommandSP("sp_NombreRutaDoc");
            b.AddParameter("@IdDoc ", doc.Id, SqlDbType.Int);

            Models.Documento resultado = new Models.Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Nombre = reader["Nombre"].ToString();

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
                resultado.FechaRevision = reader["FechaRevision"].ToString();
                resultado.FechaPublicacion = reader["FechaPublicacion"].ToString();
                resultado.FechaVencimiento = reader["FechaVencimiento"].ToString();
                resultado.FechaProximaRevision = reader["FechaProximaRevision"].ToString();

                resultado.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"].ToString());
                resultado.TipoDoc = reader["TipoDoc"].ToString();
                resultado.ClasificacionDoc = reader["ClasificacionDoc"].ToString();
                resultado.Registro = reader["Registrado"].ToString();

                resultado.PalabraClave = reader["PalabrasClave"].ToString();
                resultado.Version = reader["Version"].ToString();
                resultado.Descripcion = reader["Descripcion"].ToString();
                resultado.NmArchivo = reader["NmArchivo"].ToString();
                
                resultado.MedioAlmacenamiento = reader["MedioAlmacenamiento"].ToString();
                resultado.Extension = reader["Extension"].ToString();
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
                resultado.NmArchivoword = reader["NmArchivoword"].ToString();
                resultado.PalabraClave = reader["PalabrasClave"].ToString();
              

                resultado.TipoDocumento = reader["TipoDocumento"].ToString();
                resultado.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"].ToString());
                resultado.IdTipoArchivo = Convert.ToInt32(reader["IdTipoArchivo"].ToString());
                resultado.IdMedioAlmacenamiento = Convert.ToInt32(reader["IdMedioAlmacenamiento"].ToString());
                resultado.IdClasificacion = Convert.ToInt32(reader["IdClasificacion"].ToString());
  
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
        
        public Models.Documento Documento_custodiaA(Models.NuevoDocumento nuevoDocumento)
        {
            b.ExecuteCommandSP("SP_Documento_custodiaA");
            b.AddParameter("@IdTemporal", nuevoDocumento.Idtemporal, SqlDbType.Int);
            b.AddParameter("@IdDoc", nuevoDocumento.Id, SqlDbType.Int);

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

        public List<Models.Documento> SP_INF_Prestado(Models.Documento documento)
        {
            b.ExecuteCommandSP("SP_INF_Prestado");
            b.AddParameter("@IdUser", documento.IdUsuario, SqlDbType.VarChar);
            b.AddParameter("@Id", documento.Id, SqlDbType.VarChar);

            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    Id = Convert.ToInt32(reader["Dias"].ToString()),

                    FechaPublicacion = reader["FechaRegistro"].ToString(),
                    FechaVencimiento = reader["FechaT"].ToString(),
                    
                    //Nombre = reader["Nombre"].ToString(),
                    NmOriginal = reader["Custodia"].ToString(),
                    Entrega = Convert.ToInt32(reader["Devuelto"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        } 
        public List<Models.Documento> CheckDocPrestado()
        {
            b.ExecuteCommandSP("CheckDocPrestado");

            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    NmArchivo = reader["Documento"].ToString(),
                    DiasRestantes = Convert.ToInt32(reader["DiasRestantes"].ToString()),
                    Nombre = reader["Receptor"].ToString(),
                    Descripcion = reader["Email_Receptor"].ToString(),
                    Elaboro = reader["Emisor"].ToString(),
                    NmOriginal = reader["Email_Emisor"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        public Models.Documento SP_NPrestar(Models.Documento Ddoc)
        {

            b.ExecuteCommandSP("SP_NPrestar");
            b.AddParameter("@IdDocumento", Ddoc.Id, SqlDbType.Int);

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
        public Models.Documento SP_ActualizarDoc(Models.NuevoDocumento nuevoDocumento)

        {
            b.ExecuteCommandSP("SP_ActualizarDoc");
            b.AddParameter("@Id", nuevoDocumento.Id, SqlDbType.Int);
            b.AddParameter("@IdUser", nuevoDocumento.IdUsuario, SqlDbType.Int);
            b.AddParameter("@NmArchivo", nuevoDocumento.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@NMArchivoEditable", nuevoDocumento.NmArchivoword, SqlDbType.NVarChar);
            b.AddParameter("@Version", nuevoDocumento.Version, SqlDbType.NVarChar);
           




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
        public Models.Documento SP_ActualizarDocPDF(Models.NuevoDocumento nuevoDocumento)

        {
            b.ExecuteCommandSP("SP_ActualizarDocPDF");
            b.AddParameter("@Id", nuevoDocumento.Id, SqlDbType.Int);
            b.AddParameter("@IdUser", nuevoDocumento.IdUsuario, SqlDbType.Int);
            b.AddParameter("@NmArchivo", nuevoDocumento.NmArchivo, SqlDbType.NVarChar);
            b.AddParameter("@Version", nuevoDocumento.Version, SqlDbType.NVarChar);

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
        public Models.Documento DocumentoInsertarPermiso(Models.Documento Doc)

        {
            b.ExecuteCommandSP("DocumentoInsertarPermiso");
            b.AddParameter("@IdDoc", Doc.Id, SqlDbType.Int);
            b.AddParameter("@IdUser", Doc.IdUsuario, SqlDbType.Int);

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
        public Models.Documento HabilitarPermisos(Models.Documento Doc)

        {
            b.ExecuteCommandSP("HabilitarPermisos");
            b.AddParameter("@IdDoc", Doc.Id, SqlDbType.Int);
            b.AddParameter("@IdUser", Doc.IdUsuario, SqlDbType.Int);

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
        public Models.Documento Bloqueop(Models.Documento Doc)

        {
            b.ExecuteCommandSP("Bloqueop");
            b.AddParameter("@IdDoc", Doc.Id, SqlDbType.Int);
           

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
        public Models.Documento BloqueopR(Models.Documento Doc)

        {
            b.ExecuteCommandSP("BloqueopR");
            b.AddParameter("@IdDoc", Doc.Id, SqlDbType.Int);
           

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
        public Models.Documento DesbloP(Models.Documento Doc)

        {
            b.ExecuteCommandSP("DesbloP");
            b.AddParameter("@IdDoc", Doc.Id, SqlDbType.Int);
           

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

        //public List<Models.Documento> DOC_Versionamiento(Models.Documento documento)
        //{
        //    const string consulta = "DOC_Versionamiento";
        //    b.ExecuteCommandSP(consulta);
        //    b.AddParameter("@IdDoc", documento.Id, SqlDbType.VarChar);


        //    List<Models.Documento>
        //        resultado = new List<Models.Documento>();
        //        var reader = b.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        resultado = JsonConvert.DeserializeObject<List<Models.Documento>>(reader.GetValue(0).ToString());
        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();

        //    return resultado;
        //}

        public List<Models.Documento> DOC_Versionamiento(Models.Documento documento)
        {
            b.ExecuteCommandSP("DOC_Versionamiento");
            b.AddParameter("@IdDoc", documento.Id, SqlDbType.VarChar);

            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    Nombre = reader["Editores"].ToString(),
                    NmArchivo = reader["NmArchivo"].ToString(),
                    NmArchivoword = reader["NMArchivoEditable"].ToString(),
                    Version = reader["Version"].ToString(),
                    Registro = reader["Fecha"].ToString(),
                    NmOriginal = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }




        public Models.Documento SolicitudPDF(Models.Documento Documento)

        {
            b.ExecuteCommandSP("ConsultarSolicitud");
            b.AddParameter("@Id_documento", Documento.Id, SqlDbType.Int);
            b.AddParameter("@Id_solicitante", Documento.IdUsuario, SqlDbType.Int);


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

        public Models.Documento InsertarSolicitud(Models.Documento Documento)

        {
            b.ExecuteCommandSP("InsertarSolicitud");
            b.AddParameter("@Id_documento", Documento.Id, SqlDbType.Int);
            b.AddParameter("@Id_solicitante", Documento.IdUsuario, SqlDbType.Int);


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


        public Models.Documento ConteoSolicitud(Models.Documento Documento)

        {
            b.ExecuteCommandSP("ConteoSolicitud");
            b.AddParameter("@Id", Documento.IdUsuario, SqlDbType.Int);


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


        public List<Models.Documento> ListSolicitud(Models.Documento documento)
        {
            b.ExecuteCommandSP("ListSolicitud");
            b.AddParameter("@Id", documento.IdUsuario, SqlDbType.VarChar);

            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),  
                    Nombre = reader["Nombre"].ToString(),
                    Estatus= reader["Estado"].ToString(),
                    Elaboro = reader["Solicitante"].ToString(),
                    FechaPublicacion = reader["FechaSolicitud"].ToString(),
                    IdClasificacion= Convert.ToInt32(reader["Id_estado"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public Models.Documento SolicitudAceptar(Models.Documento Documento)

        {
            b.ExecuteCommandSP("SolicitudAceptar");
            b.AddParameter("@Id", Documento.Id, SqlDbType.Int);


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
        public Models.Documento SolicitudNegar(Models.Documento Documento)

        {
            b.ExecuteCommandSP("SolicitudNegar");
            b.AddParameter("@Id", Documento.Id, SqlDbType.Int);


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

        public Models.Documento DocVersion(Models.Documento Adoc)
        {
            b.ExecuteCommandSP("DocVersion");
            
            b.AddParameter("@Version", Adoc.Version, SqlDbType.NVarChar);
            
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




        public List<Models.Documento> FechaInterfaz(Models.Documento documento)
        {
            b.ExecuteCommandSP("FechasDocumento_Seleccionar");
            b.AddParameter("@Id", documento.Id, SqlDbType.VarChar);

            List<Models.Documento> resultado = new List<Models.Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento item = new Models.Documento()
                {
                    FRevision = Convert.ToInt32(reader["FechaRevision"].ToString()),
                    FPublicacion = Convert.ToInt32(reader["FechaPublicacion"].ToString()),
                    FEntradaVigor = Convert.ToInt32(reader["FechaEntradaVigor"].ToString()),
                    FProximaRevision = Convert.ToInt32(reader["FechaProximaRevision"].ToString()),
                    FVencimiento = Convert.ToInt32(reader["FechaVencimiento"].ToString()),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
