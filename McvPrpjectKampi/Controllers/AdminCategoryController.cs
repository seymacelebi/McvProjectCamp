using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace McvPrpjectKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult results = categoryvalidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = categoryManager.GetByID(id);
            categoryManager.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = categoryManager.GetByID(id);
            return View(categoryvalue);

        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            categoryManager.CategoryUpdate(p);
            return RedirectToAction("Index");

        }

    }
}