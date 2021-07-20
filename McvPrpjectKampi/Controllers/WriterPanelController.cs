using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Business.ValidationRules;
using FluentValidation.Results;

namespace McvPrpjectKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        Context c = new Context();


        [HttpGet]
        public ActionResult WriterProfile()
        {
            string p = (string)Session["WriterMail"];
            ViewBag.d = p;
            int id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return RedirectToAction("AllHeading", "WriterPanel");
        }

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();      
            var values = headingManager.GetAllByWriter(writeridinfo);
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
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
          
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writeridinfo;
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
        public ActionResult AllHeading(int sayfa = 1)
        {
            var headings = headingManager.GetAll().ToPagedList(sayfa, 4);
            return View(headings);
        }

    }
}