namespace Application.DTO
{
    public class BookDTO : CreateBookDTO
    {
        public int? Id { get; set; }
    }

    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string BookGenreId { get; set; }
        public string BookGenreName { get; set; }
    }


}
