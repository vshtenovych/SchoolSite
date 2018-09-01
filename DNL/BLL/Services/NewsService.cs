using BLL.AutoMapper;
using BLL.Interfaces;
using BLL.ViewModels;
using Core.Entities;
using DAL.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class NewsService : Service<News, NewsViewModel>, INewsService
    {
        public NewsService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.News)
        {

        }

    }
}
