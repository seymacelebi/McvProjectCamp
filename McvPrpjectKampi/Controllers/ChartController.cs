using Business.Concrete;
using DataAccess.EntityFramework;
using McvPrpjectKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Line()
        {
            return View();
        }

        public ActionResult Column()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LineChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ColumnChart()
        {
            return Json(ContentList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClasses> BlogList()
        {
            List<CategoryClasses> categoryClasses = new List<CategoryClasses>();
            categoryClasses.Add(new CategoryClasses()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryClasses.Add(new CategoryClasses()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            categoryClasses.Add(new CategoryClasses()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            categoryClasses.Add(new CategoryClasses()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return categoryClasses;
        }

        public List<CategoryClasses> CategoryList()
        {
            List<CategoryClasses> categoryClasses = new List<CategoryClasses>();
            foreach (var item in categoryManager.GetList())
            {
                categoryClasses.Add(new CategoryClasses()
                {
                    CategoryName = item.CategoryName,
                    CategoryCount = headingManager.GetCountByCategory(item.CategoryId)
                });
            }
            return categoryClasses;
        }

        public List<ContentClasses> ContentList()
        {
            List<ContentClasses> contentClasses = new List<ContentClasses>();
            foreach (var item in writerManager.GetList())
            {
                contentClasses.Add(new ContentClasses()
                {
                    WriterName = item.WriterName,
                    ContentCount = contentManager.GetnumberByWriter(item.WriterId)
                });
            }
            return contentClasses;
        }
    }
}