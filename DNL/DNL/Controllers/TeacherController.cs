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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DNL.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IUserValidator<AppUser> _userValidator;
        private IPasswordValidator<AppUser> _passwordValidator;
        private IPasswordHasher<AppUser> _passwordHasher;
        private readonly ISubjectService _subjectService;


        public TeacherController(ITeacherService teacherService, ISubjectService subjectService, IPasswordHasher<AppUser> passwordHash, IPasswordValidator<AppUser> passValid, UserManager<AppUser> userManager, IUserValidator<AppUser> userValid, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _subjectService = subjectService;
            _teacherService = teacherService;
            _userValidator = userValid;
            _roleManager = roleManager;
            _passwordValidator = passValid;
            _passwordHasher = passwordHash;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MethodicalAssociationSquad(int id)
        {
            var result = _teacherService.GetTeachersByAssociationId(id);
            ViewBag.AssociationName = _teacherService.GetAssociationNameById(id);
            return View(result);
        }

        public IActionResult Administration()
        {
            var result = _teacherService.GetAdministration();
            return View(result);
        }


        public IActionResult MethodicalAssociationPresentation(int id)
        {
            return View(_teacherService.GetAssociationById(id));
        }



        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        public IActionResult MethodicalAssociationIndex()
        {
            var result = _teacherService.GetMethodicalAssociations();
            return View(result);
        }




        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult MethodicalAssociationCreate() => View();
        [HttpPost]
        public IActionResult MethodicalAssociationCreate(MethodicalAssociationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _teacherService.AddAssociation(model);
                return RedirectToAction("MethodicalAssociationIndex");
            }
            return View(model);
        }




        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        public ViewResult MethodicalAssociationEdit(int id)
        {
            return View(_teacherService.GetAssociationById(id));
        }
        [HttpPost]
        public IActionResult MethodicalAssociationEdit(MethodicalAssociationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _teacherService.UpdateAssociation(model);
                return RedirectToAction("MethodicalAssociationIndex");
            }
            return View(model);
        }





        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.Categories = Enum.GetValues(typeof(CategoryEnum));
            ViewBag.Ranks = Enum.GetValues(typeof(RankEnum));
            ViewBag.AdminPositions = Enum.GetValues(typeof(AdministrationPositionEnum));
            ViewData["Subjects"] = new SelectList(_subjectService.GetAll(), "Name", "Name");
            ViewData["MethodicalAssociationId"] = new SelectList(_teacherService.GetMethodicalAssociations(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = model.Email.Split("@").First();
                AppUser user = new AppUser
                {
                    UserName = userName,
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






        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            
            if (user != null)
            {
                ViewData["MethodicalAssociationId"] = new SelectList(_teacherService.GetMethodicalAssociations(), "Id", "Name");
                ViewData["Subjects"] = new SelectList(_subjectService.GetAll(), "Name", "Name");
                var teacher = _teacherService.GetTeacherByUserId(id);
                return View(teacher);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherViewModel model)
        {
            AppUser user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.Photo = model.Photo;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                IdentityResult validEmail = await _userValidator.ValidateAsync(_userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(model.Password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.Password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user,
                        model.Password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && model.Password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        _teacherService.UpdateTeacher(model);
                        return Redirect("~/Admin/Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

    }
}