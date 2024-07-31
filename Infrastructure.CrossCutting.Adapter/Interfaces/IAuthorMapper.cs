using Application.DTO;
using Domain.Models;

namespace Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IAuthorMapper
    {
        Author MapToEntity(AuthorDTO AuthorDTO);

        IEnumerable<AuthorDTO> MapListAuthorsToDTO(IEnumerable<Author> authors);

        AuthorDTO MapToDTO(Author Author);
    }
}
