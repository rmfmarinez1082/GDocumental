using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ListarCompartir
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.ListarCompartir> SP_ListarCompartir(Models.ListarCompartir listarCompartir)
        {
            b.ExecuteCommandSP("SP_ListarCompartir");
            b.AddParameter("@IdUsuario", listarCompartir.IdUsuario, SqlDbType.VarChar);

            List<Models.ListarCompartir> resultado = new List<Models.ListarCompartir>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.ListarCompartir item = new Models.ListarCompartir()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    prestamo = Convert.ToInt32(reader["Prestamo"].ToString()),
                    Compartido = Convert.ToInt32(reader["Compartido"].ToString()),
                    FechaEntradaVigor = reader["FechaEntradaVigor"].ToString(),
                    FechaVencimiento = reader["FechaVencimiento"].ToString(),
                    Nombre = reader["Nombre"].ToString(),
                    NombreWord = reader["NmArchivoword"].ToString(),
                    IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"].ToString()),
                    PalabrasClave = reader["PalabrasClave"].ToString(),
                    Editable = Convert.ToInt32(reader["Editable"].ToString()),
                    NmOriginal = reader["NmArchivo"].ToString(),
                    Propietario = reader["Propietario"].ToString(),
                    Version = reader["Version"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
