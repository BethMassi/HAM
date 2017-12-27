using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HAMApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(T item);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAsync(bool forceRefresh = false);
    }
}
