using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_listadoGeneral
    {
        Data.Cat_listadoGeneral _Cat_listadoGeneral = new Data.Cat_listadoGeneral();
        public List<Models.Cat_listadoGeneral> SP_listadoGeneral(Models.Cat_listadoGeneral cat_ListadoGeneral)
        {
            return _Cat_listadoGeneral.SP_listadoGeneral(cat_ListadoGeneral);
        }
    }
}
