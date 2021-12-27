using CacheEducation.Data;

namespace CacheEducation.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationContext _context;
        
        public AuthorService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Initialize()
        {
            if (!_context.Author.Any())
            {
                try
                {
                    var book = new Models.Book
                    {
                        Title = "English 1-4",
                        YearOfRelease = 2002,
                    };
                    await _context.Book.AddAsync(book);
                    await _context.SaveChangesAsync();

                    var country = new Models.Country
                    {
                        Name = "Russia"
                    };
                    await _context.Country.AddAsync(country);
                    await _context.SaveChangesAsync();

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

                    await _context.Author.AddAsync(author);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

        public Task AddAsync(Models.Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Author> GetRecordByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Author> GetTheYoungestAsync()
        {
            throw new NotImplementedException();
        }

        
    }
}
