using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_13_data
{
    public class HomeController: Controller
    {
       public IActionResult Index()
        {
            return View();
        }
    }
}
