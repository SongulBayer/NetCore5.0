using BusinessLayer.Concrate;
using BusinessLayer.AbstractValidator;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult GetBlogByWriter()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var val = bm.GetBlogListWithCategoryByWriter(writerId);
            return View(val);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddBlog()
        {
            List<SelectListItem> categoryValues = (from x in cm.getList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddBlog(Blog p)
        {

            BlogRules br = new BlogRules();
            ValidationResult result = br.Validate(p);
            List<SelectListItem> categoryValues = (from x in cm.getList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = 8;
                bm.Add(p);
                return RedirectToAction("GetBlogByWriter", "Blog");
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
        [AllowAnonymous]
        public IActionResult DeleteBlog(int id)
        {
            var val = bm.TgetByid(id);
            bm.Delete(val);
            return RedirectToAction("GetBlogByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var val = bm.TgetByid(id);
            List<SelectListItem> categoryValues = (from x in cm.getList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(val);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
         
            p.WriterId = 8;
            bm.Update(p);
            return RedirectToAction("GetBlogByWriter");
        }
    }
}
