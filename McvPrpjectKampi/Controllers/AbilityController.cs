using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class AbilityController : Controller
    {
        AbilityManager abm = new AbilityManager(new EfAbilityDal());
        // GET: Abilities
        public ActionResult Index()
        {
            var abilityValues = abm.GetList();
            return View(abilityValues);
        }
       
        [HttpGet]
        public ActionResult NewAbility()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAbility(Ability ability)
        {
            ability.UserId = 1;
            abm.Add(ability);
            return RedirectToAction("Index", "Abilities");
        }
        public ActionResult DeleteAbility(int id)
        {
            var value = abm.GetById(id);

            abm.Delete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAbility(int id)
        {

            var value = abm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditAbility(Ability h)
        {
            abm.Update(h);
            return RedirectToAction("Index");
        }
    }
}