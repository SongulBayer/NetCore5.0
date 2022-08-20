using BusinessLayer.AbstractValidator;
using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace NetCore5._0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {//sayda birden başlayarak her sayfada üçer veri olacak şekilde listelenir
            var val = cm.getList().ToPagedList(page,3);
            return View(val);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryRules cr = new CategoryRules();
            ValidationResult result = cr.Validate(p);
            if (result.IsValid)
            {
                p.CategoryStatus = true;
                cm.Add(p);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteCategory(int id)
        {
            var val = cm.TgetByid(id);
            cm.Delete(val);
            return RedirectToAction("Index");
        }
    }
}
