using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class CCompartir
    {
        ManejoDatos b = new ManejoDatos();


        public Models.CCompartir SP_Compartir(Models.CCompartir compartir)
        {
            b.ExecuteCommandSP("SP_Compartir");
            b.AddParameter("@IdEntidad", compartir.IdEntidad, SqlDbType.VarChar);
            b.AddParameter("@IdAsignacion", compartir.IdAsignacion, SqlDbType.VarChar);
            b.AddParameter("@IdDocumento", compartir.IdDocumento, SqlDbType.VarChar);
            Models.CCompartir resultado = new Models.CCompartir();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public Models.CCompartir FCompartir(Models.CCompartir Ncompartir)
        {
            b.ExecuteCommandSP("FCompartir");
            b.AddParameter("@IdDoc", Ncompartir.Id, SqlDbType.VarChar);
            Models.CCompartir resultado = new Models.CCompartir();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {

                resultado.Id = Convert.ToInt32(reader["Id"].ToString());

            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
