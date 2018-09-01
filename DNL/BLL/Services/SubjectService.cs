using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class SubjectService : Service<Subject, SubjectViewModel>, ISubjectService
    {
        public SubjectService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Subjects)
        {

        }
    }
}
