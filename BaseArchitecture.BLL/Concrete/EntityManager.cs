using AdaBis.Dal.SqlServer.Abstract;
using AdaBis.Dal.SqlServer.Concrete;
using BaseArchitecture.BLL.Abstract;

namespace BaseArchitecture.BLL.Concrete
{
    public class EntityManager<T> : IEfEntityDal<T>, IEntityManager<T> where T : class
    {
        private readonly IEfEntityDal<T> _repositoryDal;
        public ApplicationDbContext ApplicationDbContext { get; set; }

        public EntityManager(ApplicationDbContext applicationDbContext)
        {
            _repositoryDal = new EfEntityDal<T>(applicationDbContext);
            ApplicationDbContext = applicationDbContext;
            ErrorMessage = string.Empty;
        }

        public void Dispose()
        {
            _repositoryDal.Dispose();
        }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public List<T> GetAll()
        {
            List<T>? entities = null;
            try
            {
                entities = _repositoryDal.GetAll();
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }

            return entities;
        }

        public List<T> Get(Func<T, bool> predicate)
        {
            List<T>? entities = null;
            try
            {
                entities = _repositoryDal.Get(predicate);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }

            return entities;
        }

        public T GetFirst(Func<T, bool> predicate)
        {
            T? entity = null;
            try
            {
                entity = _repositoryDal.GetFirst(predicate);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }

            return entity;
        }

        public T Find(int? id)
        {
            T? entity = null;
            try
            {
                entity = _repositoryDal.Find(id);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }

            return entity;
        }

        public void Add(T entity)
        {
            try
            {
                _repositoryDal.Add(entity);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public void AddRange(IEnumerable<T> range)
        {
            try
            {
                _repositoryDal.AddRange(range);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public void Delete(int id)
        {
            try
            {
                _repositoryDal.Delete(id);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public void DeleteRange(IEnumerable<T> range)
        {
            try
            {
                _repositoryDal.DeleteRange(range);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _repositoryDal.Update(entity);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public void UpdateRange(IEnumerable<T> range)
        {
            try
            {
                _repositoryDal.UpdateRange(range);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public void UndoDelete(int id)
        {
            try
            {
                _repositoryDal.UndoDelete(id);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public void Detach(T entity)
        {
            try
            {
                _repositoryDal.Detach(entity);
                IsSuccessful = true;
            }
            catch (Exception e)
            {
                IsSuccessful = false;
                ErrorMessage = e.Message;
            }
        }

        public bool SaveChanges()
        {
            IsSuccessful = _repositoryDal.SaveChanges();
            if (!IsSuccessful) ErrorMessage = _repositoryDal.ErrorMessage;

            return IsSuccessful;
        }
    }
}
