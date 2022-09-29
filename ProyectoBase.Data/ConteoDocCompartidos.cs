using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ConteoDocCompartidos
    {

        ManejoDatos b = new ManejoDatos();

        public List<Models.ConteoDocCompartidos> SP_ConteoDocCompartidos(Models.ConteoDocCompartidos ConteoDoc_Compartidos)
        {
            b.ExecuteCommandSP("SP_ConteoDocCompartidos");
            b.AddParameter("@Id", ConteoDoc_Compartidos.Id, SqlDbType.VarChar);

            List<Models.ConteoDocCompartidos> resultado = new List<Models.ConteoDocCompartidos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.ConteoDocCompartidos item = new Models.ConteoDocCompartidos()
                {
                    compartidos = reader["compartidos"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ConteoDocCompartidos>SP_ConteoVigente(Models.ConteoDocCompartidos vigente)
        {
            b.ExecuteCommandSP("SP_ConteoVigente");
            b.AddParameter("@Id", vigente.Id, SqlDbType.VarChar);

            List<Models.ConteoDocCompartidos> resultado = new List<Models.ConteoDocCompartidos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.ConteoDocCompartidos item = new Models.ConteoDocCompartidos()
                {
                    TotalDocVigente = reader["TotalDocVigente"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Models.ConteoDocCompartidos> SP_ConteoVencido(Models.ConteoDocCompartidos vencido)
        {
            b.ExecuteCommandSP("SP_ConteoVencido");
            b.AddParameter("@Id", vencido.Id, SqlDbType.VarChar);

            List<Models.ConteoDocCompartidos> resultado = new List<Models.ConteoDocCompartidos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.ConteoDocCompartidos item = new Models.ConteoDocCompartidos()
                {
                    TotalDocVencido = reader["TotalDocVencido"].ToString()

                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
