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

        public NewsViewModel GetJobInfo(int jobId)
        {
            var job = Database.News.Get(1);//.Include(jobs => jobs.JobSkills).ThenInclude(jobs => jobs.Skill).FirstOrDefault(jobs => jobs.Id == jobId);

            var jobViewModel = Mapping.Map<News, NewsViewModel>(job);
            return jobViewModel;
        }
    }
}
