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
    public class PhotoGalleryController : Controller
    {
        private readonly IAlbumService _albumService;

        public PhotoGalleryController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_albumService.GetAll());
        }

        public IActionResult AllAlbums()
        {
            var result = _albumService.GetAll();
            return View(result);
        }

        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admins")]
        [HttpGet]
        public ViewResult CreateAlbum() => View();
        [HttpPost]
        public IActionResult CreateAlbum(AlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                _albumService.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admins")]
        public ViewResult EditAlbum(int id)
        {
            return View(_albumService.Get(id));
        }
        [HttpPost]
        public IActionResult EditAlbum(AlbumViewModel model)
        {
            if (ModelState.IsValid)
            {
                _albumService.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}