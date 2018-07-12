using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IService<TEntity, TViewModel> where TEntity : class where TViewModel : class
    {
        IEnumerable<TViewModel> GetAll();

        TViewModel Get(int? id);

        void Add(TViewModel T);

        void Update(TViewModel T);

        void Delete(int? id);

        void Dispose();
    }
}
