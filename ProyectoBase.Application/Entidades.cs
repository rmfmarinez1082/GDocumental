using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Entidades
    {
        Data.Entidades _entidades = new Data.Entidades();
        public List<Models.Entidades> SP_ListEntidad()
        {
            return _entidades.SP_ListEntidad();
        }
    }
}
