using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using AdaBis.Dal.SqlServer.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AdaBis.Dal.SqlServer.Concrete
{
    public class EfEntityDal<T> : IEfEntityDal<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public DbSet<T> DbSet { get; set; }
        public string ErrorMessage { get; set; }

        public EfEntityDal(ApplicationDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public List<T> GetAll()
        {
            return DbSet.ToList();
        }

        public List<T> Get(Func<T, bool> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public T Find(int? id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> range)
        {
            DbSet.AddRange(range);
        }

        public void Delete(int id)
        {
            var kayit = DbSet.Find(id);
            if (kayit == null) return;

            DbSet.Remove(kayit);
        }

        public void DeleteRange(IEnumerable<T> range)
        {
            DbSet.RemoveRange(range);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> range)
        {
            range.ToList().ForEach(entity => _context.Entry(entity).State = EntityState.Modified);
        }

        public void UndoDelete(int id)
        {
            _context.Entry(Find(id)).State = EntityState.Modified;
            _context.Entry(Find(id)).State = EntityState.Unchanged;
        }

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool SaveChanges()
        {
            try
            {
                ErrorMessage = string.Empty;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Kayıt yapılırken bilinmeyen bir hata oluştu: {ex.Message} {ex.InnerException?.Message}";

                //if (ex.InnerException?.InnerException is SqlException sqlException && sqlException.Errors.OfType<SqlError>()
                //        .Any(se => se.Number == 2601 || se.Number == 2627)) /* Primary Key veya Unique Key Constraint ihlâli */
                //{
                //    ErrorMessage = "Girmek istediğiniz kayıt veritabanında zaten mevcut.";
                //}

                return false;
            }

            return true;
        }
    }

}
