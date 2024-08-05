using Application.DTO;
using Domain.Models;
using Infrastructure.CrossCutting.Adapter.Interfaces;

namespace Infrastructure.CrossCutting.Adapter.Map
{
    public class BookGenreMapper : IBookGenreMapper
    {

        List<BookGenreDTO> bookGenreDTOs = new List<BookGenreDTO>();

        public BookGenre MapToEntity(BookGenreDTO bookGenreDTO)
        {
            BookGenre bookGenre = new BookGenre
            {
                Id = bookGenreDTO.Id,
                Name = bookGenreDTO.Name
            };

            return bookGenre;
        }

        public BookGenre MapToEntity(CreateBookGenreDTO bookGenreDTO)
        {
            BookGenre bookGenre = new BookGenre
            {
                Name = bookGenreDTO.Name
            };

            return bookGenre;
        }

        public BookGenreDTO MapToDTO(BookGenre BookGenre)
        {
            BookGenreDTO bookGenreDTO = new BookGenreDTO
            {
                Id = BookGenre.Id,
                Name = BookGenre.Name
            };

            return bookGenreDTO;
        }

        public IEnumerable<BookGenreDTO> MapListBookGenresToDTO(IEnumerable<BookGenre> bookGenres)
        {
            foreach (var bookGenre in bookGenres)
            {
                BookGenreDTO bookGenreDTO = MapToDTO(bookGenre);
                bookGenreDTOs.Add(bookGenreDTO);
            }

            return bookGenreDTOs;
        }
    }
}

