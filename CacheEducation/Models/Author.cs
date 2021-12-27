namespace CacheEducation.Models
{
    /// <summary>
    /// Entity for Author
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get;set; }
        public int YearOfBirth { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();
    }
}
