using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Controllers
{
    public class DashBoardsController : Controller
    {
        public IActionResult Index()
        {
            BlogManager bm = new BlogManager(new EfBlogRepository());
            var val = bm.GetBlogListWithCategory();

            Context c = new Context();
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterId == 8).Count();
            ViewBag.v3 = c.Categories.Count().ToString();
            return View(val);
        }
    }
}
