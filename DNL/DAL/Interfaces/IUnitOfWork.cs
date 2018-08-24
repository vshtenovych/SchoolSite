using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<News> News { get; }
        IRepository<Personal> Personals { get; }
        IRepository<Album> Albums { get; }
        IRepository<MethodicalAssociation> MethodicalAssociations { get; }
        IRepository<Teacher> Teachers { get; }

        void Save();

        void Dispose(bool disposing);
        void Dispose();
    }
}
