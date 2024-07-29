using Application.DTO;
using Domain.Models;

namespace Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperAuthor
    {
        Author MapperToEntity(AuthorDTO AuthorDTO);

        IEnumerable<AuthorDTO> MapperListAuthors(IEnumerable<Author> authors);

        AuthorDTO MapperToDTO(Author Author);
    }
}
