using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Repository
{
    public class DocumentoTipoArchivo
    {
        //    internal AccesoDatos b { get; set; } = new AccesoDatos();

        //    protected List<Models.DocumentosTipoArchivo> Seleccionar()
        //    {
        //        b.ExecuteCommandQuery("SELECT id, extensiones, tammaxpermitido, permitir FROM DocumentosTipoArchivo");
        //        List<Models.DocumentosTipoArchivo> resultado = new List<Models.DocumentosTipoArchivo>();
        //        var reader = b.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Models.DocumentosTipoArchivo item = new Models.DocumentosTipoArchivo()
        //            {
        //                Id = int.Parse(reader["id"].ToString()),
        //                Extensiones = reader["extensiones"].ToString(),
        //                TamMaxPermitido = int.Parse(reader["tammaxpermitido"].ToString()),
        //                Permitir = bool.Parse(reader["permitir"].ToString()),
        //            };
        //            resultado.Add(item);
        //        }
        //        b.CloseConnection();
        //        return resultado;
        //    }

        //    protected Models.DocumentosTipoArchivo SeleccionarPorId(string id)
        //    {
        //        b.ExecuteCommandQuery("SELECT id, extensiones, tammaxpermitido, permitir FROM DocumentosTipoArchivo WHERE id=@id");
        //        b.AddParameter("@id", id, SqlDbType.Int);
        //        Models.DocumentosTipoArchivo resultado = new Models.DocumentosTipoArchivo();
        //        var reader = b.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            resultado.Id = int.Parse(reader["id"].ToString());
        //            resultado.Extensiones = reader["extensiones"].ToString();
        //            resultado.TamMaxPermitido = int.Parse(reader["tammaxpermitido"].ToString());
        //            resultado.Permitir = bool.Parse(reader["permitir"].ToString());

        //        }
        //        b.CloseConnection();
        //        return resultado;
        //    }

        //    protected int SeleccionarSiPermitido(string extension)
        //    {
        //        b.ExecuteCommandQuery("SELECT tammaxpermitido FROM DocumentosTipoArchivo WHERE extensiones LIKE @extension AND permitir = 1");
        //        b.AddParameter("@extension", "%" + extension + "%", SqlDbType.NVarChar, 150);
        //        return int.Parse(b.SelectString());
        //    }


        //    protected int Agregar(Models.DocumentosTipoArchivo items)
        //    {
        //        b.ExecuteCommandQuery("INSERT INTO DocumentosTipoArchivo (extensiones, tammaxpermitido, permitir) VALUES(@extensiones, @tammaxpermitido, @permitir)");
        //        b.AddParameter("@extensiones", items.Extensiones, SqlDbType.NVarChar, 150);
        //        b.AddParameter("tammaxpermitido", items.TamMaxPermitido, SqlDbType.Int);
        //        b.AddParameter("@permitir", items.Permitir, SqlDbType.Bit);
        //        return b.InsertUpdateDelete();
        //    }


        //    protected int Modificar(Models.DocumentosTipoArchivo items)
        //    {
        //        b.ExecuteCommandQuery("UPDATE DocumentosTipoArchivo SET extensiones=@extensiones, tammaxpermitido=@tammaxpermitido, permitir=@permitir WHERE id=@id");
        //        b.AddParameter("@extensiones", items.Extensiones, SqlDbType.NVarChar, 150);
        //        b.AddParameter("tammaxpermitido", items.TamMaxPermitido, SqlDbType.Int);
        //        b.AddParameter("@permitir", items.Permitir, SqlDbType.Bit);
        //        b.AddParameter("@id", items.Id, SqlDbType.Int);
        //        return b.InsertUpdateDelete();
        //    }
        //}
    }
}
