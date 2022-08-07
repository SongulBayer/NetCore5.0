using Microsoft.AspNetCore.Mvc;
using NetCore5._0.Areas.Admin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Areas.Admin.Controllers
{
 [Area("Admin")]
    public class WriterController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        public IActionResult GetWriterById(int Writerid)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == Writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        public static List<WriterModel> writers = new List<WriterModel>
        {
            new WriterModel
            {
                Id=1,
                Name="Song"
            },
            new WriterModel
            {
                Id=2,
                Name="Buse"
            },
            new WriterModel
            {
                Id=3,
                Name="Sun"
            }
        };
    }
}
