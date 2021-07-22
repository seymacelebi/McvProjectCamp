using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        //List<Admin> GetList();

        //Admin GetById(int id);
        //Admin GetByName(String name);

        //void ChangeRole(int id, String role);
        //void AdminDelete(Admin admin);
        //void AdminUpdate(Admin admin);
        //void AdminAdd(AdminForRegisterDto adminregister, string password);
        ////void AdminAdd(Admin admin);
        void Add(Admin admin);
        void Update(Admin admin);
        void Delete(Admin admin);
        List<Admin> GetAdmins();
        Admin GetById(int id);
    }
}
