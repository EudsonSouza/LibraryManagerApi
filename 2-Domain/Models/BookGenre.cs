namespace Domain.Models
{
    public class BookGenre : Base
    {
        public string Name { get; set; }

        // Navigation property
        public ICollection<Book> Books { get; set; }
    }
}
