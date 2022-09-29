using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_TipoArchivo
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_TipoArchivo> Cat_TipoArchivo_Listar()
        {
            b.ExecuteCommandSP("Cat_TipoArchivo_Listar");
            List<Models.Cat_TipoArchivo> resultado = new List<Models.Cat_TipoArchivo>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_TipoArchivo item = new Models.Cat_TipoArchivo()
                {
                    Extension = reader["Extension"].ToString(),
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
