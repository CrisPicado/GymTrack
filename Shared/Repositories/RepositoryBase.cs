using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using System.Linq.Expressions;


namespace Shared.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _entities;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _entities.ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _entities;
            query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}