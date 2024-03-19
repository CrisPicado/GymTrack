using Application.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;

        public RepositoryBase(ApplicationDbContext context)
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
            _context.Save();
        }
    }
}