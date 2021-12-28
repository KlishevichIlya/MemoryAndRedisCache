using CacheEducation.Models;

namespace CacheEducation.Dtos
{
    public class AuthorDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int YearOfBirth { get; set; }
        public int CountryId { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
