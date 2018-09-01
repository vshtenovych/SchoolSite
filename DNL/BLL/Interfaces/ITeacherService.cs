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
        void AddAssociation(MethodicalAssociationViewModel model);
        string GetAssociationNameById(int id);
        IEnumerable<TeacherViewModel> GetAdministration();
        TeacherViewModel GetTeacherByUserId(string userId);
        void UpdateTeacher(TeacherViewModel model);
        MethodicalAssociationViewModel GetAssociationById(int id);
        void UpdateAssociation(MethodicalAssociationViewModel model);
    }
}
