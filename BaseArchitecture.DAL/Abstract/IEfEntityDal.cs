using System;
using System.Collections.Generic;

namespace BaseArchitecture.DAL.Abstract
{
    public interface IEfEntityDal<T> : IDisposable where T : class
    {
        string ErrorMessage { get; set; }

        List<T> GetAll();

        List<T> Get(Func<T, bool> predicate);

        T GetFirst(Func<T, bool> predicate);

        T Find(int? id);

        void Add(T entity);

        void AddRange(IEnumerable<T> entity);

        void Delete(int id);

        void DeleteRange(IEnumerable<T> range);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> range);

        void UndoDelete(int id);

        void Detach(T entity);

        bool SaveChanges();
    }
}
