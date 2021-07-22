using Business.Abstract;
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
    public class AuthorizationController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        AdminRoleManager roleManager = new AdminRoleManager(new EfAdminRoleDal());
        public ActionResult Index()
        {
            var result = adminManager.GetAdmins();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> valueadminrole = (from c in roleManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.Id.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminUserName, loginDto.AdminPassword);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> valueadminrole = (from c in roleManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.Id.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;
            var result = adminManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            admin.Status = true;
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var result = adminManager.GetById(id);
            if (result.Status == true)
            {
                result.Status = false;
            }
            else
            {
                result.Status = true;
            }
            adminManager.Update(result);
            return RedirectToAction("Index");
        }
    }
}