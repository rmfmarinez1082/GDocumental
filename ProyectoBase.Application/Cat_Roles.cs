using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Cat_Roles
    {
        Data.Cat_Roles _Roles = new Data.Cat_Roles();
        
        public List<Models.Cat_Roles> Cat_Roles_listar()
        {
            return _Roles.Cat_Roles_listar();
        }
    }
}
