using BLL.Interfaces;
using BLL.ViewModels;
using DAL.Interfaces;
using EF.Entities;
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
