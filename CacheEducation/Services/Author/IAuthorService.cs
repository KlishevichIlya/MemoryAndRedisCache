using ModelAuthor = CacheEducation.Models.Author;

namespace CacheEducation.Services.Author
{
    public interface IAuthorService : IGenericService<ModelAuthor>
    {
        Task<ModelAuthor> GetTheYoungestAsync();
    }
}
