using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class Cat_Tipo_Documento
    {
        ManejoDatos b = new ManejoDatos();

        public List<Models.Cat_Tipo_Documento> Cat_Tipo_Documento_Listar()
        {
            b.ExecuteCommandSP("Cat_Tipo_Documento_Listar");
            List<Models.Cat_Tipo_Documento> resultado = new List<Models.Cat_Tipo_Documento>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Models.Cat_Tipo_Documento item = new Models.Cat_Tipo_Documento()
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


        public Models.Cat_Tipo_Documento SP_Dobligatorio(Models.Cat_Tipo_Documento Tdocumento)
        {
            b.ExecuteCommandSP("SP_Dobligatorio");
            b.AddParameter("@Id", Tdocumento.Id, SqlDbType.Int);

            Models.Cat_Tipo_Documento resultado = new Models.Cat_Tipo_Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["Id"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public Models.Cat_Tipo_Documento ValidarSolicitiudEdit(Models.Cat_Tipo_Documento TDoc)
        {
            b.ExecuteCommandSP("ValidarSolicitiudEdit");
            b.AddParameter("@Id", TDoc.Id, SqlDbType.Int);

            Models.Cat_Tipo_Documento resultado = new Models.Cat_Tipo_Documento();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id = Convert.ToInt32(reader["R"].ToString());
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }



}
