using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.ViewComponents.Blog
{
    public class BlogLast3Posts:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
         public IViewComponentResult Invoke()
        {
            var val = bm.Get3Blogs();
            return View(val);
        }
    }
}
