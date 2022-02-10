using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // Generic Constraint
    // Class : Reference Type
    // IEntity : IEntity olabilir veya IEntity implemente'e eden bir nesne olabilir.
    // new() : new'lenebilir olmalıdır. Bu sayade IEntity koyulamaz.

    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
