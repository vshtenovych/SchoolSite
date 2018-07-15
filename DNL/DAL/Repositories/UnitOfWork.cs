using DAL.Interfaces;
using EF;
using EF.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppIdentityDbContext _context;

        private IRepository<News> _newsRepository;



        public UnitOfWork(AppIdentityDbContext context)
        {
            _context = context;
        }

        public IRepository<News> News => _newsRepository ?? (_newsRepository = new Repository<News>(_context.News));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
