using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Controllers
{ 
    [AllowAnonymous]
    public class Message2Controller : Controller
    {
       
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult GetAllMessages()
        {
            int id = 9;
            var val = mm.getInboxListByWriter(id);
            return View(val);
        }
        public IActionResult MessageDetails(int id)
        {
            Context c = new Context();
            
            var val = mm.TgetByid(id);
            return View(val);
        }
    }
}
