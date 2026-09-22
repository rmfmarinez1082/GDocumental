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

        public Models.Cat_ClasificacionDoc SP_ConteoClasificacion()
        {
            b.ExecuteCommandSP("SP_ConteoClasificacion");

            Models.Cat_ClasificacionDoc resultado = new Models.Cat_ClasificacionDoc();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Publica = reader["Publica"].ToString();
                resultado.Interno = reader["Interno"].ToString();
                resultado.Restringida = reader["Restringida"].ToString();
                resultado.Confidencial = reader["Confidencial"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


    }
}
