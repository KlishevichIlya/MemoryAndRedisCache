namespace CacheEducation.Models
{
    /// <summary>
    /// Entity for book
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public List<BookAuthor> BookAuthor { get; set; } = new List<BookAuthor>();
    }
}
