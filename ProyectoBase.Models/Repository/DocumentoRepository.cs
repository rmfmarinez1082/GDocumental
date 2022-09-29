using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoBase.Models;

namespace ProyectoBase.Models.Repository
{
    public class DocumentoRepository
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();


        protected int Agregar(Documento items)
        {
            string consulta = "INSERT INTO documentos (nombre, idusuario,palabraclave, version, vigencia, IdClasificacion, fecha ";
            //if (items.SubClasificacion > 0)
                consulta += ",estatus,elaboro";
            consulta += ") " +
            "VALUES(@nombre, @idusuario,@palabraclave, @version, @vigencia,@IdClasificacion, @fecha";
            //if (items.SubClasificacion > 0)
                consulta += ",@estatus,@elaboro";
            consulta += ");" +
            "SELECT @@IDENTITY";
            
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@nombre", items.Nombre, SqlDbType.NVarChar, 50);
            b.AddParameter("@idusuario", items.IdUsuario, SqlDbType.Int);
            b.AddParameter("@palabraclave", items.PalabraClave, SqlDbType.NVarChar, 50);
            b.AddParameter("@version", items.Version, SqlDbType.NVarChar, 50);
            b.AddParameter("@vigencia", items.Vigencia, SqlDbType.Bit);
            b.AddParameter("@IdClasificacion", items.IdClasificacion, SqlDbType.Int);
            b.AddParameter("@fecha", items.Fecha, SqlDbType.DateTime);
            b.AddParameter("@estatus", items.Estatus, SqlDbType.NVarChar, 50);
            b.AddParameter("@elaboro", items.Elaboro, SqlDbType.NVarChar, 50);
            return b.SelectWithReturnValue();
        }

        protected List<Documento> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idusuario, palabraclave, version, vigencia, IdClasificacion, fecha, estatus, elaboro FROM documentos");
            List<Documento> resultado = new List<Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Documento item = new Documento();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                item.IdUsuario = int.Parse(reader["idusuario"].ToString());
                item.PalabraClave = reader["palabraclave"].ToString();
                item.Version = reader["version"].ToString();
                item.Vigencia = bool.Parse(reader["vigencia"].ToString());
                item.IdClasificacion = int.Parse(reader["IdClasificacion"].ToString());
                item.Fecha = DateTime.Parse(reader["fecha"].ToString());
                item.Estatus = reader["estatus"].ToString();
                item.Elaboro = reader["elaboro"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;
            
        }

        protected Documento SeleccionarPorId(string id)
        {
            b.ExecuteCommandQuery("SELECT id, nombre, idusuario, palabraclave, version, vigencia, IdClasificacion, fecha, estatus,elaboro FROM documentos WHERE id=@id");
            b.AddParameter("@id", id, SqlDbType.Int);
            Documento resultado = new Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = int.Parse(reader["id"].ToString());
                resultado.Nombre = reader["nombre"].ToString();
                resultado.IdUsuario = int.Parse(reader["idusuario"].ToString());
                resultado.PalabraClave = reader["palabraclave"].ToString();
                resultado.Version = reader["version"].ToString();
                resultado.Vigencia = bool.Parse(reader["vigencia"].ToString());
                resultado.IdClasificacion = int.Parse(reader["IdClasificacion"].ToString());
                resultado.Fecha = DateTime.Parse(reader["fecha"].ToString());
                resultado.Estatus = reader["estatus"].ToString();
                resultado.Elaboro = reader["elaboro"].ToString();
            }
            b.CloseConnection();
            return resultado;
        }


    }
}
