using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mod = ProyectoBase.Models;


namespace ProyectoBase.Models.Business
{
    public class Documento : Repository.DocumentoRepository
    {
        public int Agregar_Registro(mod.Documento items)
        {
            return Agregar(items);
        }

        public List<mod.Documento> Seleccionar_Todo()
        {
            return Seleccionar();
        }

        public mod.Documento Seleccionar_PorId(string id)
        {
            return SeleccionarPorId(id);
        }

    }
}
