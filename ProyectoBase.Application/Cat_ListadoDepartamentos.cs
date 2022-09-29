using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_ListadoDepartamentos
    {
        Data.Cat_ListadoDepartamentos _Cat_ListadoDepartamentos = new Data.Cat_ListadoDepartamentos();
        public List<Models.Cat_ListadoDepartamentos> SP_LisDep(Models.Cat_ListadoDepartamentos cat_ListadoDepartamentos)
        {
            return _Cat_ListadoDepartamentos.SP_LisDep(cat_ListadoDepartamentos);
        }
    }
}
