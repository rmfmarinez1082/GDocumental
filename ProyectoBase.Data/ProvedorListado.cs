using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ProvedorListado
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.ProvedorListado> SP_ProvedoresListado()
        {
            b.ExecuteCommandSP("SP_ProvedoresListado");
            List<Models.ProvedorListado> resultado = new List<Models.ProvedorListado>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.ProvedorListado item = new Models.ProvedorListado()
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
