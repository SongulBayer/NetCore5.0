﻿using Microsoft.AspNetCore.Mvc;
using NetCore5._0.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore5._0.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass{
                categoryname="Teknoloji",categorycount=5
            }); list.Add(new CategoryClass{
                categoryname="Yazılım",categorycount=9
            }); list.Add(new CategoryClass{
                categoryname="Magazin",categorycount=7
            }); list.Add(new CategoryClass{
                categoryname="Spor",categorycount=15
            });
            return Json(new { jsonlist = list });
        }
    }
}
