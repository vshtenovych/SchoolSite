using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        //IRepository<Company> Companies { get; }


        void Save();

        void Dispose(bool disposing);
        void Dispose();
    }
}
