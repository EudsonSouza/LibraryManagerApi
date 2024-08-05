using Application.DTO;
using Domain.Models;

namespace Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IBookGenreMapper
    {
        BookGenre MapToEntity(BookGenreDTO bookGenreDTO);

        BookGenre MapToEntity(CreateBookGenreDTO bookGenreDTO);

        IEnumerable<BookGenreDTO> MapListBookGenresToDTO(IEnumerable<BookGenre> bookGenres);

        BookGenreDTO MapToDTO(BookGenre bookGenre);
    }
}
