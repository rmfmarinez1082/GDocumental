using Newtonsoft.Json;
using ProyectoBase.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Data
{
    public class ImgData
    {
        ManejoDatos b = new ManejoDatos();

        public List<Img> ObtenerImagenesPorDocumento(Img model)
        {
            b.ExecuteCommandSP("ObtenerImagenesPorDocumento");
            b.AddParameter("@Id", model.Id, SqlDbType.Int);

            List<Img> resultado = new List<Img>();

            using (var reader = b.ExecuteReader())
            {
                if (reader.Read())
                {
                    resultado = JsonConvert.DeserializeObject<List<Img>>(reader.GetValue(0).ToString());
                }
            }
            return resultado;
        }
        
        public Img ImagenDocumentoEliminar(Img model)
        {
            b.ExecuteCommandSP("ImagenDocumentoEliminar");
            b.AddParameter("@Id", model.Id, SqlDbType.Int);

            Img resultado = new Img();

            using (var reader = b.ExecuteReader())
            {
                if (reader.Read())
                {
                    resultado = JsonConvert.DeserializeObject <Img>(reader.GetValue(0).ToString());
                }
            }
            return resultado;
        }
    }
}
