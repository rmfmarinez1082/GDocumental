using Newtonsoft.Json;
using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Roles
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Roles> Cat_Roles_listar()
        {
            b.ExecuteCommandSP("Cat_Roles_listar");
            List<Models.Cat_Roles> resultado = new List<Models.Cat_Roles>();

            using (var reader = b.ExecuteReader())
            {
                if (reader.Read())
                {
                    resultado = JsonConvert.DeserializeObject<List<Models.Cat_Roles>>(reader.GetValue(0).ToString());
                }
            }
            return resultado;
        }
    }
}