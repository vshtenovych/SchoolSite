using BLL.AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class TeacherService : Service<Teacher, TeacherViewModel>, ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Teachers)
        {
            
        }

        public void AddTeacher(string userId, TeacherViewModel model)
        {
            Database.Teachers.Add(new Teacher { UserId = userId, Category = model.Category, MethodicalAssociationId = 1 });
            Database.Save();
        }
        public IEnumerable<MethodicalAssociationViewModel> GetMethodicalAssociations()
        {
            var result = Database.MethodicalAssociations.GetAll();
            return Mapping.Map<IEnumerable<MethodicalAssociation>, IEnumerable<MethodicalAssociationViewModel>>(result);
        }

        public IEnumerable<TeacherViewModel> GetTeachersByAssociationId(int id)
        {
            var result = Database.Teachers.GetAll().Include(teacher => teacher.AppUser).Where(teacher => teacher.MethodicalAssociationId == id);
            return Mapping.Map<IEnumerable<Teacher>, IEnumerable<TeacherViewModel>>(result);
        }
    }
}
