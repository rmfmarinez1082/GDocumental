using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Tipo_Documento
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Tipo_Documento> Cat_Tipo_Documento_Listar()
        {
            b.ExecuteCommandSP("Cat_Tipo_Documento_Listar");
            List<Models.Cat_Tipo_Documento> resultado = new List<Models.Cat_Tipo_Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Tipo_Documento item = new Models.Cat_Tipo_Documento()
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
