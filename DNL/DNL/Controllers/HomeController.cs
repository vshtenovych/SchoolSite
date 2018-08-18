using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DNL.Models;
using Microsoft.AspNetCore.Authorization;
using BLL.Interfaces;

namespace DNL.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            var news = _newsService.GetAll().Reverse();

            return View(news);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Statut()
        {
            return View();
        }
        public IActionResult License()
        {
            return View();
        }
        public IActionResult Vacancies()
        {
            return View();
        }
        public IActionResult EntryRules()
        {
            return View();
        }
        public IActionResult MethodicalWork()
        {
            return View();
        }
        public IActionResult EducationalActivities()
        {
            return View();
        }
        public IActionResult Achievements()
        {
            return View();
        }
        public IActionResult WorkPlan()
        {
            return View();
        }
        public IActionResult DirectorMeeting()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        } 
        public IActionResult FinancialStatements()
        {
            return View();
        }
        public IActionResult PedagogicalMeetings()
        {
            return View();
        }
    }
}

