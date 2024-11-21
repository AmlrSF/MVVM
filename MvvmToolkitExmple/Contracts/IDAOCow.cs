using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvvmToolkitExmple.Services
{
    public interface IDAOCow<T>
    {
        Task<int> CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        Task<List<T>> ReadAllAsync();
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
