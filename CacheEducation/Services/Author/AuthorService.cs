using CacheEducation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CacheEducation.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationContext _context;
        private readonly IMemoryCache _memoryCache;
        
        public AuthorService(ApplicationContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public void Initialize()
        {
            if (!_context.Author.Any())
            {               
                var book = new Models.Book
                {
                    Title = "English 1-4",
                    YearOfRelease = 2002,
                };
                _context.Book.Add(book);               

                var country = new Models.Country
                {
                    Name = "Russia"
                };
                _context.Country.Add(country);                

                var author = new Models.Author
                {
                    FirstName = "Ivan",
                    SecondName = "Ivanov",
                    YearOfBirth = 1972,
                    Country = country,
                };
                author.BookAuthor = new List<Models.BookAuthor>
                {
                    new Models.BookAuthor
                    {
                        Author = author,
                        Book = book,
                    }
                };

                _context.Author.Add(author);
                _context.SaveChanges();                
            }
        }

        public async Task AddAsync(Models.Author entity)
        {
            await _context.Author.AddAsync(entity);
            var res = await _context.SaveChangesAsync();
            if(res > 0)
            {
                _memoryCache.Set(entity.Id, entity,
                    new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
            }
        }

        public async Task<IEnumerable<Models.Author>> GetAllAsync()
        {
            if(!_memoryCache.TryGetValue("allUsers", out IEnumerable<Models.Author> authors))
            {
                authors =  await _context.Author.AsNoTracking().ToListAsync();                
                if (authors.Any())
                {
                    _memoryCache.Set("allUsers", authors,
                       new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }                
            }
            return authors;
        }

        public async Task<Models.Author> GetRecordByIdAsync(int id)
        {            
            if(!_memoryCache.TryGetValue(id, out Models.Author author))
            {
                author = await _context.Author.AsNoTracking().Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == id);
                if(author != null)
                {
                    _memoryCache.Set(author.Id, author,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            return author;
        }


        public async Task<Models.Author> GetTheYoungestAsync()
        {
            var youngestAuthor = await _context.Author.OrderBy(x => x.YearOfBirth).FirstOrDefaultAsync();
            return youngestAuthor;           
        }

        
    }
}
