namespace Application.DTO
{
    public class BookGenreDTO : CreateBookGenreDTO
    {
        public int? Id { get; set; }
    }

    public class CreateBookGenreDTO
    {
        public string Name { get; set; }
    }

}
