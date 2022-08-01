using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.ViewComponents.Writer
{
    [AllowAnonymous]
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager mn = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int id = 9;
            var val = mn.getInboxListByWriter(id);
            return View(val);
        }
    }
}
