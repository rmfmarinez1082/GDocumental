using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class List_Doc
    {
        Data.List_Doc _list_Doc = new Data.List_Doc();
        public List<Models.List_Doc> SP_ListarDocumentos(Models.List_Doc list_Doc)
        {
            return _list_Doc.SP_ListarDocumentos(list_Doc);
        }

        public List<Models.List_Doc> SP_SeleccionarPorId(Models.List_Doc list_DocID)
        {
            return _list_Doc.SP_SeleccionarPorId(list_DocID);
        }

        public List<Models.List_Doc> SP_RegistroDelete()
        {
            return _list_Doc.SP_RegistroDelete();
        }

        public List<Models.List_Doc> DetalleDocCompartido(Models.List_Doc listarDoc)
        {
            return _list_Doc.DetalleDocCompartido(listarDoc);
        }
    }
}
