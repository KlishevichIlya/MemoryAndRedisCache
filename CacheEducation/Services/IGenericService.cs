namespace CacheEducation.Services
{
    public interface IGenericService<T> where T : class
    {
        Task Initialize();
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<T> GetRecordByIdAsync(int id);
    }
}
