using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {
            var contentvalues = contentManager.GetListByWriter();
            return View(contentvalues);
        }
    }
}