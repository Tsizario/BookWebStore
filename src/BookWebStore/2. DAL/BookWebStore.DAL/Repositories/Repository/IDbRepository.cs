using System.Linq.Expressions;

namespace BookWebStore.DAL.Repositories.Abstractions
{
    public interface IDbRepository<T> where T : class
    {
        public IQueryable<T> AllItems { get; }

        Task<IEnumerable<T>> GetAllItemsAsync(Expression<Func<T, bool>> filter = null, string includeProps = null);

        Task<T> GetItemAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true, string includeProps = null);

        Task<bool> AddItemAsync(T entity);

        Task<bool> RemoveItemAsync(Guid id);

        Task RemoveItemsAsync(IEnumerable<T> entities);
    }
}