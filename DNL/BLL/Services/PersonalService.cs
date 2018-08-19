using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PersonalService : Service<Personal, PersonalViewModel>, IPersonalService
    {
        public PersonalService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.Personals)
        {

        }
    }
}
