using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetList(p);
            return View(values.ToList());
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetListById(id);
            return View(contentvalues);
        }
    }
}