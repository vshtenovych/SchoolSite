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
        private IRepository<Album> _albumRepository;
        private IRepository<MethodicalAssociation> _associationRepository;
        private IRepository<Teacher> _teacherRepository;
        private IRepository<Subject> _subjectRepository;
        private IRepository<TeacherSubject> _teacherSubjectRepository;


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IRepository<News> News => _newsRepository ?? (_newsRepository = new Repository<News>(_context.News));
        public IRepository<Personal> Personals => _personalRepository ?? (_personalRepository = new Repository<Personal>(_context.Personals));
        public IRepository<Album> Albums => _albumRepository ?? (_albumRepository = new Repository<Album>(_context.Albums));
        public IRepository<MethodicalAssociation> MethodicalAssociations => _associationRepository ?? (_associationRepository = new Repository<MethodicalAssociation>(_context.MethodicalAssociations));
        public IRepository<Teacher> Teachers => _teacherRepository ?? (_teacherRepository = new Repository<Teacher>(_context.Teachers));
        public IRepository<Subject> Subjects => _subjectRepository ?? (_subjectRepository = new Repository<Subject>(_context.Subjects));
        public IRepository<TeacherSubject> TeacherSubjects => _teacherSubjectRepository ?? (_teacherSubjectRepository = new Repository<TeacherSubject>(_context.TeacherSubjects));



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
