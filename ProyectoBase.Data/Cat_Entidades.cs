using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Entidades
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Entidades> SP_lisCat_Entidades()
        {
            b.ExecuteCommandSP("SP_lisCat_Entidades");
            List<Models.Cat_Entidades> resultado = new List<Models.Cat_Entidades>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Entidades item = new Models.Cat_Entidades()
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
