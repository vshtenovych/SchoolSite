using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DNL.Controllers
{
    public class PersonalController : Controller
    {
        private readonly IPersonalService _personalService;
        public PersonalController(IPersonalService personalService)
        {
            _personalService = personalService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Administration()
        {
            var result = _personalService.GetAll();   
            return View(result);
        }

    }
}