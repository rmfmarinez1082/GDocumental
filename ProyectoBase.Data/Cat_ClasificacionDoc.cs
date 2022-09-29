using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_ClasificacionDoc
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_ClasificacionDoc> Cat_ClasificacionDoc_Listar()
        {
            b.ExecuteCommandSP("Cat_ClasificacionDoc_Listar");
            List<Models.Cat_ClasificacionDoc> resultado = new List<Models.Cat_ClasificacionDoc>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ClasificacionDoc item = new Models.Cat_ClasificacionDoc()
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
