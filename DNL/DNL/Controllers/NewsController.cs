using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ViewModels;
using DNL.Infrastructure;
using Microsoft.AspNetCore.Authorization;
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
        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        public ViewResult Index()
        {
            return View(_newsService.GetAll());
        }

        public IActionResult AllNews()
        {
            return View(_newsService.GetAll());
        }

        public IActionResult NewsDetails(int newsId)
        {
            var result = _newsService.Get(newsId);
            return View(result);
        }

        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Create() => View();
        [HttpPost]
        public IActionResult Create(NewsViewModel model)
        {
            model.DateOfPost = DateTime.Now;
            if (ModelState.IsValid)
            {
                _newsService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        public ViewResult Edit(int id)
        {
            return View(_newsService.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                _newsService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _newsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}