

using System.Linq.Expressions;

namespace Domain.Interfaces;
    public interface IGenericRepoEntity<T> where T : class
    {
        
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);

        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);

        // Task<T> GetByKeyCompoundAsync(params object[] keyValues);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
        Task<(int totalRegistros, IEnumerable<T> registros)> GetAllAsync(int pageIndex, int pageSize, int _search);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }