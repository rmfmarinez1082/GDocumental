using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class Sistema
    {
        Data.Sistema _Sistema = new Data.Sistema();
        public Models.Sistema DataSystem()
        {
            return _Sistema.DataSystem();
        }
    }
}
