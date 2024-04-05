namespace DigitalLibrary.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? YearOfIssue { get; set; }

        // Навигационные свойства:
        public List<User> Users { get; set; } = new List<User>();

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Author> Authors { get; set; } = new List<Author>();
    }
}