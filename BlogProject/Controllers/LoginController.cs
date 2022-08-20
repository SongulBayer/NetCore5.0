using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCore5._0.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
              x.WriterPassword == p.WriterPassword);
            if (datavalue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                //"a" string değerinin sebebi:
                /*Eğer string parametre girilmezse  kimlik doğrulama olmadan bir oturum başlatılıyor.
                 * Bu sebepten hala sistemde hiçbir sayfayı göremez halde oluyoruz. */
                /*ClaimsIdentity(IEnumerable<Claim>)	
                  Numaralandırılmış nesne koleksiyonu kullanarak sınıfının yeni bir örneğini ClaimsIdentity Claim başlatır.

                 ClaimsIdentity(IEnumerable<Claim>, String)	
                  Belirtilen talepler ve kimlik doğrulama türüyle sınıfının yeni bir örneğini ClaimsIdentity başlatır.*/
                var useridentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "DashBoards");
            }
            else
            {
                return View();

            }
        }
    }
}
//Context c = new Context();
//var values = c.Writers.FirstOrDefault(x => x.WriterPassword == p.WriterPassword &&
//  x.WriterMail == p.WriterMail);
//if (values != null)
//{
//    HttpContext.Session.SetString("username", p.WriterMail);
//    return RedirectToAction("Index", "Writer");
//}
