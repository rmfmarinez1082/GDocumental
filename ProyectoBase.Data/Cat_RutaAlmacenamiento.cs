using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_RutaAlmacenamiento
    {
        ManejoDatos b = new ManejoDatos();

        public Models.Cat_RutaAlmacenamiento Cat_RutaAlmacenamiento_Seleccionar()
        {
            b.ExecuteCommandSP("Cat_RutaAlmacenamiento_Seleccionar");


            Models.Cat_RutaAlmacenamiento resultado = new Models.Cat_RutaAlmacenamiento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
                resultado.Ruta = reader["Ruta"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
        //public Models.Cat_RutaAlmacenamiento Cat_RutaAlmacenamiento_temporal()
        //{
        //    b.ExecuteCommandSP("Cat_RutaAlmacenamiento_temporal");


        //    Models.Cat_RutaAlmacenamiento resultado = new Models.Cat_RutaAlmacenamiento();
        //    var reader = b.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        resultado.Id = Convert.ToInt32(reader["Id"].ToString());
        //        resultado.Ruta = reader["Ruta"].ToString();
        //    }
        //    reader = null;
        //    b.ConnectionCloseToTransaction();
        //    return resultado;
        //}
    }
}
