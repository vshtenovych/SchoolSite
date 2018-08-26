using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using Core.Enums;
using DNL.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DNL.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public TeacherController(ITeacherService teacherService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _teacherService = teacherService;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MethodicalAssociationSquad(int id)
        {
            var result = _teacherService.GetTeachersByAssociationId(id);
            return View(result);
        }


        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Photo = model.Photo
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // add to role
                    string role = RoleEnum.Teacher.ToString();
                    if (await _roleManager.FindByNameAsync(role) == null)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }
                    await _userManager.AddToRoleAsync(user, role);

                    _teacherService.AddTeacher(user.Id, model);

                    return Redirect("~/Admin/Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}