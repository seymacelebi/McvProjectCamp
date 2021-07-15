using Business.Abstract;
using Business.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(AdminForRegisterDto adminregister, string password)
        {
            byte[] passwordHash, passwordSalt, mailHash, mailSalt;
            HashingHelper.CreateMailHash(adminregister.Mail, out mailHash, out mailSalt);
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminRole = adminregister.AdminRole,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminUserNameHash = mailHash,
                AdminUserNameSalt = mailSalt,
                AdminUserName = adminregister.UserName,
                Status = true,
                Mail = adminregister.Mail

            };
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public void ChangeRole(int id, string role)
        {
            var value = _adminDal.Get(x => x.AdminId == id);
            value.AdminRole = role;
            _adminDal.Update(value);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }


        public Admin GetByName(string name)
        {
            return _adminDal.Get(x => x.AdminUserName == name);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List(x => x.Status == true);
        }
    }
}
