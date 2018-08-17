using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DNL.Controllers
{
    public class TimetableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}