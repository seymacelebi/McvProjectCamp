using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminRoleManager : IAdminRoleService
    {
        IAdminRoleDal _adminRole;

        public AdminRoleManager(IAdminRoleDal adminRoleDal)
        {
            _adminRole = adminRoleDal;
        }
        public List<AdminRole> GetList()
        {
            return _adminRole.List(); 
        }
    }
}
