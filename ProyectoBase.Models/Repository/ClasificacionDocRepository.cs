using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProyectoBase.Models.Repository
{
    public class ClasificacionDocRepository
    {
        internal AccesoDatos b { get; set; } = new AccesoDatos();

        protected List<ClasificacionDoc> Seleccionar()
        {
            b.ExecuteCommandQuery("SELECT id, nombre FROM ClasificacionDoc");
            List<ClasificacionDoc> resultado = new List<ClasificacionDoc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                ClasificacionDoc item = new ClasificacionDoc();
                item.Id = int.Parse(reader["id"].ToString());
                item.Nombre = reader["nombre"].ToString();
                resultado.Add(item);
            }
            b.CloseConnection();
            return resultado;

        }
    }
}
