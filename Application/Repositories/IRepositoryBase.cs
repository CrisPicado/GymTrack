using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IRepositoryBase
    {
        public interface IRepositoryBase<T> where T : Entity
        {
            List<T> GetAll();

            T Get(Expression<Func<T, bool>> predicate);

            void Insert(T entity);

            void Update(T entity);

            void Delete(T entity);

            void Save();

        }
    }
}
