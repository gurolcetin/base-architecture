using System;
using System.Collections.Generic;

namespace BaseArchitecture.BLL.Abstract
{
    public interface IEntityManager<T>
    {
        void Dispose();

        bool IsSuccessful { get; set; }
        string ErrorMessage { get; set; }

        List<T> GetAll();

        List<T> Get(Func<T, bool> predicate);

        T GetFirst(Func<T, bool> predicate);

        T Find(int? id);

        void Add(T entity);

        void AddRange(IEnumerable<T> range);

        void Delete(int id);

        void DeleteRange(IEnumerable<T> range);

        void Update(T entity);
        
        void UpdateRange(IEnumerable<T> range);

        void UndoDelete(int id);

        void Detach(T entity);

        bool SaveChanges();
    }
}
