using EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<News> News { get; }


        void Save();

        void Dispose(bool disposing);
        void Dispose();
    }
}
