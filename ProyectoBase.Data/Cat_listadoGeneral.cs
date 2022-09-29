using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
   public class Cat_listadoGeneral
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_listadoGeneral> SP_listadoGeneral(Models.Cat_listadoGeneral cat_ListadoGeneral)
        {
            b.ExecuteCommandSP("SP_listadoGeneral");
            b.AddParameter("@Id", cat_ListadoGeneral.Id, SqlDbType.VarChar);

            List<Models.Cat_listadoGeneral> resultado = new List<Models.Cat_listadoGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_listadoGeneral item = new Models.Cat_listadoGeneral()
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
