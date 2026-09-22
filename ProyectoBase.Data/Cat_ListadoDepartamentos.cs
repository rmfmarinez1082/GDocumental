using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_ListadoDepartamentos
    {

        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_ListadoDepartamentos> SP_LisDep(Models.Cat_ListadoDepartamentos cat_ListadoDepartamentos)
        {
            b.ExecuteCommandSP("SP_LisDep");
            b.AddParameter("@Id", cat_ListadoDepartamentos.Id, SqlDbType.VarChar);

            List<Models.Cat_ListadoDepartamentos> resultado = new List<Models.Cat_ListadoDepartamentos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ListadoDepartamentos item = new Models.Cat_ListadoDepartamentos()
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
        public List<Models.Cat_ListadoDepartamentos> SP_CatEmpresaPuestos(Models.Cat_ListadoDepartamentos cat_ListadoDepartamentos)
        {
            b.ExecuteCommandSP("SP_CatEmpresaPuestos");
            b.AddParameter("@Id", cat_ListadoDepartamentos.Id, SqlDbType.VarChar);

            List<Models.Cat_ListadoDepartamentos> resultado = new List<Models.Cat_ListadoDepartamentos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ListadoDepartamentos item = new Models.Cat_ListadoDepartamentos()
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

        public List<Models.Cat_ListadoDepartamentos> EmpresaGrupo_Listar(Models.Cat_ListadoDepartamentos cat_ListadoDepartamentos)
        {
            b.ExecuteCommandSP("EmpresaGrupo_Listar");
            b.AddParameter("@Id", cat_ListadoDepartamentos.Id, SqlDbType.VarChar);

            List<Models.Cat_ListadoDepartamentos> resultado = new List<Models.Cat_ListadoDepartamentos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_ListadoDepartamentos item = new Models.Cat_ListadoDepartamentos()
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
