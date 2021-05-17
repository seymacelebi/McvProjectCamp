using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context context = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            var toplamKategori = context.Categories.Count().ToString();
            ViewBag.toplamKategori = toplamKategori;
          

            var value2 = context.Headings.Count(x => x.CategoryId == 11).ToString();
            ViewBag.value2 = value2;


            var value3 = context.Writers.Where(n => n.WriterName.Contains("a") || n.WriterName.Contains("A")).Count();
            ViewBag.value3 = value3;


            var value4 = context.Categories.Where(u => u.CategoryId == context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count())
               .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.value4 = value4;


            var value5 = context.Categories.Where(n => n.CategoryStatus == true)
                .Count() - context.Categories.Where(n => n.CategoryStatus == false).Count();
            ViewBag.value5 = value5;
            return View();
        }
    }
}