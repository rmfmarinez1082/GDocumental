using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Sistema
    {
        ManejoDatos b = new ManejoDatos();
        public Models.Sistema DataSystem()
        {
           
            b.ExecuteCommandSP("DataSystem");

            Models.Sistema resultado = new Models.Sistema();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {  
                //resultado.Versionamiento = Convert.ToInt32(reader["Versionamiento"].ToString());
                resultado.NombreSistema = reader["NombreSistema"].ToString();
                resultado.Acronimo = reader["Acronimo"].ToString();
                resultado.RutaLogo = reader["RutaLogo"].ToString();
                resultado.NombreEmpresa = reader["NombreEmpresa"].ToString();
                resultado.url_Imagen = reader["url_Imagen"].ToString();
                resultado.url_Sitio = reader["url_Sitio"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
            
        }
    }
}
