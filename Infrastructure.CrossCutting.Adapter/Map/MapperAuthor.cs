using Application.DTO;
using Domain.Models;
using Infrastructure.CrossCutting.Adapter.Interfaces;

namespace Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperAuthor : IMapperAuthor
    {

        List<AuthorDTO> authorDTOs = new List<AuthorDTO>();

        public Author MapToEntity(AuthorDTO authorDTO)
        {
            Author author = new Author
            {
                Id = authorDTO.Id,
                Name = authorDTO.Name
            };

            return author;
        }

        public AuthorDTO MapToDTO(Author Author)
        {
            AuthorDTO authorDTO = new AuthorDTO
            {
                Id = Author.Id,
                Name = Author.Name
            };

            return authorDTO;
        }

        public IEnumerable<AuthorDTO> MapListAuthorsToDTO(IEnumerable<Author> authors)
        {
            foreach (var author in authors)
            {
                AuthorDTO authorDTO = MapToDTO(author);
                authorDTOs.Add(authorDTO);
            }

            return authorDTOs;
        }
    }
}

