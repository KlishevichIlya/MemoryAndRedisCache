namespace CacheEducation.Models
{
    /// <summary>
    /// Entity for Country
    /// </summary>
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
