using Business.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAll();
            return View(aboutValues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.Add(about);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        //public ActionResult StatusActiveAndPassive(int id)
        //{
        //    //var aboutValue = aboutManager.GetById(id);
        //    //if (aboutValue.AboutStatus == true)
        //    //{
        //    //    aboutValue.AboutStatus = false;
        //    //}
        //    //else
        //    //{
        //    //    aboutValue.AboutStatus = true;
        //    //}
        //    //aboutManager.Update(aboutValue);
        //    //return RedirectToAction("Index");
        //}
    }
}
    
