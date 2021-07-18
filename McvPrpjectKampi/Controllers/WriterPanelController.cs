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
    public class WriterPanelController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }
        public ActionResult MyHeading()
        {
           //id = 4;
            var values = headingManager.GetAllByWriter();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from c in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = 4;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");       
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from c in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = c.CategoryName,
                                                      Value = c.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;

            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }

    }
}