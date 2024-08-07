namespace Domain.Models
{
    public class Book : Base 
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int BookGenreId { get; set; }

        // Navigation properties
        public Author Author { get; set; }
        public BookGenre BookGenre { get; set; }
    }
}
