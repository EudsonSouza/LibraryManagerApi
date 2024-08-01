namespace Application.DTO
{
    public class AuthorDTO : CreateAuthorDTO
    {
        public int? Id { get; set; }
    }

    public class CreateAuthorDTO
    {
        public string Name { get; set; }
    }

}
