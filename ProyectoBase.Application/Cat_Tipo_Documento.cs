using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Tipo_Documento
    {
        Data.Cat_Tipo_Documento _cat_Tipo_Documento = new Data.Cat_Tipo_Documento();
        public List<Models.Cat_Tipo_Documento> Cat_Tipo_Documento_Listar()
        {
            return _cat_Tipo_Documento.Cat_Tipo_Documento_Listar();
        }
    }
}
