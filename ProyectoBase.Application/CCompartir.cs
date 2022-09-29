using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class CCompartir
    {
        Data.CCompartir _cCompartir = new Data.CCompartir();


        public Models.CCompartir SP_Compartir(Models.CCompartir compartir)
        {
            return _cCompartir.SP_Compartir(compartir);
        }

        public Models.CCompartir FCompartir(Models.CCompartir Ncompartir)
        {
            return _cCompartir.FCompartir(Ncompartir);
        }
    }
}
