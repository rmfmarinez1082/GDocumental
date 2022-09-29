using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Documento_Versiones
    {
        Data.Documento_Versiones _Documento_Versiones = new Data.Documento_Versiones();

        public List<Models.Documento_Versiones> SP_ConteoMisDoc(Models.Documento_Versiones documento_Versiones)
        {
            return _Documento_Versiones.SP_ConteoMisDoc(documento_Versiones);
        }

    }
}
