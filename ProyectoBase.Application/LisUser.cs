using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBase.Application
{
    public class LisUser
    {
        Data.ListarDocumento _LisUser = new Data.ListarDocumento();
        public List<Models.LisUser> SP_LisUser(Models.LisUser lisUser)
        {
            return _LisUser.SP_LisUser(lisUser);
        }
        public List<Models.LisUser> SP_LisUserDepEmp(Models.LisUser LisUserDepEmp)
        {
            return _LisUser.SP_LisUserDepEmp(LisUserDepEmp);
        }

        public List<Models.LisUser> SP_LisUserper(Models.LisUser LisUserper)
        {
            return _LisUser.SP_LisUserper(LisUserper);
        }
        public List<Models.LisUser> SP_ListUserEntidad(Models.LisUser ListUserEntidad)
        {
            return _LisUser.SP_ListUserEntidad(ListUserEntidad);
        }
        public List<Models.LisUser> SP_UserExpirado()
        {
            return _LisUser.SP_UserExpirado();
        }

        public List<Models.LisUser> ListadoUsuariosGral()
        {
            return _LisUser.ListadoUsuariosGral();
        }

        public Models.LisUser Resetearpassword(Models.LisUser Usuario)
        {
            return _LisUser.Resetearpassword(Usuario);
        }
    }

}
