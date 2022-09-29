using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoBase.Application
{
   public class Cat_Almacenamiento_Documento
    {
        Data.Cat_Almacenamiento_Documento  _cat_Almacenamiento_Documento = new Data.Cat_Almacenamiento_Documento();
        public List<Models.Cat_Almacenamiento_Documento> Cat_Almacenamiento_Documento_Listar()
        {
            return _cat_Almacenamiento_Documento.Cat_Almacenamiento_Documento_Listar();
        }
    }
}
