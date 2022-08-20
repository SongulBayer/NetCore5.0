using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }     [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.ContactStatus = true;
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.AddContact(p);
            return RedirectToAction("Index","Blog");
        }
    }
}
