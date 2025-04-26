using ProyectoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ImgAplication
    {
        Data.ImgData _Data = new Data.ImgData();
        public List<Img> ObtenerImagenesPorDocumento(Img model)
        {
            return _Data.ObtenerImagenesPorDocumento(model);
        }

    }
}
