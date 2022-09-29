using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Models.Business
{
    public class Business
    {
        public Documento documento;
        public DocumentoTipoArchivo documentotipoarchivo;
        public ClasificacionDoc clasificaciondoc;
        public status status;

        public Business()
        {
            documento = new Documento();
            documentotipoarchivo = new DocumentoTipoArchivo();
            clasificaciondoc = new ClasificacionDoc();
            status = new status();
        }
    }
  
}
