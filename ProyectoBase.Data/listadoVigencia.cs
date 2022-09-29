using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class listadoVigencia
    {
        ManejoDatos b = new ManejoDatos();
        public List<Models.listadoVigencia> SP_listadoVigente(Models.listadoVigencia listarviegnte)
        {
            b.ExecuteCommandSP("SP_listadoVigente");
            b.AddParameter("@Id", listarviegnte.Id, SqlDbType.VarChar);

            List<Models.listadoVigencia> resultado = new List<Models.listadoVigencia>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.listadoVigencia item = new Models.listadoVigencia()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    DiasRestantes = Convert.ToInt32(reader["DiasRestantes"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    FechaVencimiento=reader["FechaVencimiento"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.listadoVigencia> SP_listadoVencido(Models.listadoVigencia listarvencido)
        {
            b.ExecuteCommandSP("SP_listadoVencido");
            b.AddParameter("@Id", listarvencido.Id, SqlDbType.VarChar);

            List<Models.listadoVigencia> resultado = new List<Models.listadoVigencia>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.listadoVigencia item = new Models.listadoVigencia()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    DiasRestantes = Convert.ToInt32(reader["DiasRestantes"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    FechaVencimiento = reader["FechaVencimiento"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }  
        public List<Models.listadoVigencia> SP_LisProxVence(Models.listadoVigencia listarProxvenc)
        {
            b.ExecuteCommandSP("SP_LisProxVence");
            b.AddParameter("@Id", listarProxvenc.Id, SqlDbType.VarChar);

            List<Models.listadoVigencia> resultado = new List<Models.listadoVigencia>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.listadoVigencia item = new Models.listadoVigencia()
                {
                    Id = Convert.ToInt32(reader["Id"].ToString()),
                    DiasRestantes = Convert.ToInt32(reader["DiasRestantes"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    FechaVencimiento = reader["FechaVencimiento"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
