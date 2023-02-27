using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agentstvo23.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        Task GetAsync(int id, CancellationToken Cancel = default );

        T Add(T entity);
        Task AddAsync(int id, CancellationToken Cancel = default);

        void Update(T entity);
        Task UpdateAsync(T entity, CancellationToken Cancel = default);

        void Remove(T entity);
        Task RemoveAsync(T entity, CancellationToken Cancel = default);
    }
}
