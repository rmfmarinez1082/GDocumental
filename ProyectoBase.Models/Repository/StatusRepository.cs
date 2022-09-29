using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoBase.Models.Repository
{
    public class StatusRepository
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<Status> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT id, nombre FROM status");
            List<Status> resultado = new List<Status>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Status item = new Status();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;

        }
    }
}
