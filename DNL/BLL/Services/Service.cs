using BLL.AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public abstract class Service<TEntity, TViewModel> : IService<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        public IUnitOfWork Database { get; set; }
        private readonly IRepository<TEntity> _repository;
        //private IUnitOfWork unitOfWork;
        //private IRepository<News> skills;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            Database = unitOfWork;
            _repository = repository;
        }

        //protected Service(IUnitOfWork unitOfWork, IRepository<Skill> skills)
        //{
        //    this.unitOfWork = unitOfWork;
        //    this.skills = skills;
        //}

        public IEnumerable<TViewModel> GetAll()
        {
            return Mapping.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(_repository.GetAll());
        }

        public TViewModel Get(int? id)
        {
            if (id == null)
                throw new Exception("Id wasn't set");
            var item = _repository.Get(id.Value);
            if (item == null)
                throw new Exception(typeof(TEntity) + " wasn't found");
            return Mapping.Map<TEntity, TViewModel>(item);
        }

        public void Add(TViewModel T)
        {
            if (T == null)
                throw new Exception(typeof(TEntity) + " wasn't set");
            _repository.Add(Mapping.Map<TViewModel, TEntity>(T));
            Database.Save();
        }

        public void Update(TViewModel T)
        {
            if (T == null)
                throw new Exception(typeof(TEntity) + " wasn't set");
            _repository.Update(Mapping.Map<TViewModel, TEntity>(T));
            Database.Save();
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new Exception("Id wasn't found");

            _repository.Delete(id.Value);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
