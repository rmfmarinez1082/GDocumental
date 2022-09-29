using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Entidades
    {
        Data.Cat_Entidades _entidades = new Data.Cat_Entidades();
        public List<Models.Cat_Entidades> SP_lisCat_Entidades()
        {
            return _entidades.SP_lisCat_Entidades();
        }
    }
}
