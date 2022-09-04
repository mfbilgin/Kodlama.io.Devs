using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories
{
    public interface IRepository<T> : IQuery<T> where T : Entity
    {
        T Get(Expression<Func<T, bool>> predicate);
    }
}
