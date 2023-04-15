using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
/// <summary>
/// Interface Genérica para definir os métodos do repositório
/// </summary>
/// <typeparam name="TEntity">Tipo de dado genérico</typeparam>
namespace Model.Infraestrutura.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> GetById(object id);
        void Add(T entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        Task SaveChanges();
    }
}
