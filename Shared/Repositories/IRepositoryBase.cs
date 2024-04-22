using Shared.Domain;
using System.Linq.Expressions;

namespace Shared.Repositories
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
