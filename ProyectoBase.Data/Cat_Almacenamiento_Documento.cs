using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
 public class Cat_Almacenamiento_Documento
 {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Almacenamiento_Documento> Cat_Almacenamiento_Documento_Listar()
        {
            b.ExecuteCommandSP("Cat_Almacenamiento_Documento_Listar");
            List<Models.Cat_Almacenamiento_Documento> resultado = new List<Models.Cat_Almacenamiento_Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Almacenamiento_Documento item = new Models.Cat_Almacenamiento_Documento()
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
