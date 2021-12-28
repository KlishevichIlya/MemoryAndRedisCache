namespace CacheEducation.Services
{
    public interface IGenericService<T> where T : class
    {
        void Initialize();
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task<T> GetRecordByIdAsync(int id);
    }
}
