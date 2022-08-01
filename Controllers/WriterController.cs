using BusinessLayer.Concrate;
using BusinessLayer.AbstractValidator;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore5._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
    [AllowAnonymous]
    [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.v = usermail;
            Context c = new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbar()
        {
            return PartialView();
        }
         [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        } 
        [HttpGet]
        public IActionResult EditWriter()
        {
            Context c = new Context();
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var val = wm.TgetByid(writerId);
            return View(val);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult EditWriter(Writer p)
        {
            WriterValidation wr = new WriterValidation();
            ValidationResult vr = wr.Validate(p);
            if (vr.IsValid)
            {
                p.WriterStatus = true;
                
                wm.Update(p);
                return RedirectToAction("Index","DashBoards" );
            }
            else
            {
                foreach (var item in vr.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddWriter(AddProfileImage p)
        {
            Writer w = new Writer();
            if (p.WriterImage!=null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.ConfirmPassword = p.ConfirmPassword;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.Add(w);
            return RedirectToAction("Index", "DashBoards");
        }


    }
}
