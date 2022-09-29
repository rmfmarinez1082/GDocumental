using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class ConteoDocCompartidos
    {
        Data.ConteoDocCompartidos _ConteoDocCompartidos = new Data.ConteoDocCompartidos();

        public List<Models.ConteoDocCompartidos> SP_ConteoDocCompartidos(Models.ConteoDocCompartidos conteoDocCompartidos)
        {
            return _ConteoDocCompartidos.SP_ConteoDocCompartidos(conteoDocCompartidos);
        }

        public List<Models.ConteoDocCompartidos> SP_ConteoVigente(Models.ConteoDocCompartidos conteoDocVigente)
        {
            return _ConteoDocCompartidos.SP_ConteoVigente(conteoDocVigente);
        }

        public List<Models.ConteoDocCompartidos>SP_ConteoVencido (Models.ConteoDocCompartidos conteoDocVencido)
        {
            return _ConteoDocCompartidos.SP_ConteoVencido(conteoDocVencido);
        }
    }
}
