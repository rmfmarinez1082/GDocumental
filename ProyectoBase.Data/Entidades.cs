using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Entidades
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Entidades> SP_ListEntidad()
        {
            b.ExecuteCommandSP("SP_ListEntidad");
            List<Models.Entidades> resultado = new List<Models.Entidades>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Entidades item = new Models.Entidades()
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
