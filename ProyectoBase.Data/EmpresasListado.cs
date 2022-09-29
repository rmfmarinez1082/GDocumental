using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
   public class EmpresasListado
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.EmpresasListado> SP_EmpresasListado()
        {
            b.ExecuteCommandSP("SP_EmpresasListado");
            List<Models.EmpresasListado> resultado = new List<Models.EmpresasListado>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.EmpresasListado item = new Models.EmpresasListado()
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
