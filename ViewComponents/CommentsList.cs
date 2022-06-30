using Microsoft.AspNetCore.Mvc;
using NetCore5._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.ViewComponents
{
    public class CommentsList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var values = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    UserName="s"
                },
                new UserComment
                {
                    Id=2,
                    UserName="m"
                },
                new UserComment
                {
                    Id=3,
                    UserName="a"
                }
            };
           
            return View(values);
        }
    }
}
