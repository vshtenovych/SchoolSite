using BLL.ViewModels;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ITeacherService : IService<Teacher, TeacherViewModel>
    {
        void AddTeacher(string userId, TeacherViewModel model);
        IEnumerable<MethodicalAssociationViewModel> GetMethodicalAssociations();
        IEnumerable<TeacherViewModel> GetTeachersByAssociationId(int id);
    }
}
