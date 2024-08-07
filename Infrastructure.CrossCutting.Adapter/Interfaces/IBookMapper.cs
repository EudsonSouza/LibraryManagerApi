using Application.DTO;
using Domain.Models;

namespace Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IBookMapper
    {
        Book MapToEntity(BookDTO bookDTO);

        Book MapToEntity(CreateBookDTO bookDTO);

        IEnumerable<BookDTO> MapListBooksToDTO(IEnumerable<Book> books);

        BookDTO MapToDTO(Book book);
    }
}
