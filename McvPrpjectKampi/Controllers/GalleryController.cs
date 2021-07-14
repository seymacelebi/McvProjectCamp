using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ImageFileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = ImageFileManager.GetList();
            return View(files);
        }
    }
}