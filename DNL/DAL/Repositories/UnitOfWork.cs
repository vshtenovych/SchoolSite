using Core;
using Core.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        private IRepository<News> _newsRepository;
        private IRepository<Personal> _personalRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<News> News => _newsRepository ?? (_newsRepository = new Repository<News>(_context.News));
        public IRepository<Personal> Personals => _personalRepository ?? (_personalRepository = new Repository<Personal>(_context.Personals));

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
