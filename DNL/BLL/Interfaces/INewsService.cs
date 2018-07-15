using BLL.ViewModels;
using EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface INewsService : IService<News, NewsViewModel>
    {
        NewsViewModel GetJobInfo(int jobId);
    }
}
