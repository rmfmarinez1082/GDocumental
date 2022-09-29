using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Documento_Versiones
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Documento_Versiones> SP_ConteoMisDoc(Models.Documento_Versiones documento_Versiones)
        {
            b.ExecuteCommandSP("SP_ConteoMisDoc");
            b.AddParameter("@Id", documento_Versiones.IdUsuario, SqlDbType.VarChar);

            List<Models.Documento_Versiones> resultado = new List<Models.Documento_Versiones>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Documento_Versiones item = new Models.Documento_Versiones()
                {
                    MisDocumnetos = reader["MisDocumnetos"].ToString(),

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
