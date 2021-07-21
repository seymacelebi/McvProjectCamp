using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    [AllowAnonymous]
    public class AuthorizationController : Controller
    {
        // GET: Authorization
       // IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        AdminManager adm = new AdminManager(new EfAdminDal());
        AdminRoleManager admRole = new AdminRoleManager(new EfAdminRoleDal());

        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }
        //[HttpGet]
        //public ActionResult AddAdmin()
        //{
        //    List<SelectListItem> valueadminrole = (from c in roleManager.GetRoles()
        //                                           select new SelectListItem
        //                                           {
        //                                               Text = c.RoleName,
        //                                               Value = c.RoleId.ToString()

        //                                           }).ToList();

        //    ViewBag.valueadmin = valueadminrole;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddAdmin(LoginDto loginDto)
        //{
        //    authService.Register(loginDto.AdminUserName, loginDto.AdminPassword);
        //    return RedirectToAction("Index");
        ////}

        [HttpGet]
        public ActionResult NewAdmin()
        {
            List<SelectListItem> valueRole = (from x in admRole.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            ViewBag.dgr1 = valueRole;
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(AdminForRegisterDto c)
        {
            adm.AdminAdd(c, c.Password);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult ChangeRole(int id)
        {
            List<SelectListItem> valueRole = (from x in admRole.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.RoleName,
                                                  Value = x.Id.ToString()
                                              }).ToList();
            ViewBag.dgr1 = valueRole;
            var value = adm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult ChangeRole(Admin admin)
        {

            adm.ChangeRole(admin.AdminId, admin.AdminRole);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var result = adm.GetById(id);
            if (result.Status == true)
            {
                result.Status = false;
            }
            else
            {
                result.Status = true;
            }
            adm.(result);
            return RedirectToAction("Index");
        }
    }
}