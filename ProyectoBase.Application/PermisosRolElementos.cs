using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class PermisosRolElementos
    {
        Data.PermisosRolElementos _permisosRolElementos = new Data.PermisosRolElementos();

        public List< Models.PermisosRolElementos> PermisosElementos(Models.Usuarios Usuario)
        {
            return _permisosRolElementos.PermisosElementos(Usuario);
        }
    }
}
