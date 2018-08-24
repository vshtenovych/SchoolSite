using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class TeacherService : Service<Teacher, TeacherViewModel>, ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Teachers)
        {

        }
    }
}
