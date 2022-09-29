using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class LisUser
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.LisUser> SP_LisUser(Models.LisUser lisUser)
        {
            b.ExecuteCommandSP("SP_LisUser");
            b.AddParameter("@Id", lisUser.Id, SqlDbType.VarChar);

            List<Models.LisUser> resultado = new List<Models.LisUser>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.LisUser item = new Models.LisUser()
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
