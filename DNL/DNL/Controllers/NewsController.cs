using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DNL.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public ViewResult Index()
        {
            return View(_newsService.GetAll());
        }

        public IActionResult AllNews()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create() => View();
        [HttpPost]
        public IActionResult Create(NewsViewModel client)
        {
            if (ModelState.IsValid)
            {
                _newsService.Add(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public ViewResult Edit(int id)
        {
            return View(_newsService.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(NewsViewModel client)
        {
            if (ModelState.IsValid)
            {
                _newsService.Update(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _newsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}