using Application.DTO;
using Domain.Models;
using Infrastructure.CrossCutting.Adapter.Interfaces;

namespace Infrastructure.CrossCutting.Adapter.Map
{
    public class BookMapper : IBookMapper
    {

        List<BookDTO> bookDTOs = new List<BookDTO>();

        public Book MapToEntity(BookDTO bookDTO)
        {
            Book book = new Book
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title
            };

            return book;
        }

        public Book MapToEntity(CreateBookDTO bookDTO)
        {
            Book book = new Book
            {
                Title = bookDTO.Title
            };

            return book;
        }

        public BookDTO MapToDTO(Book Book)
        {
            BookDTO bookDTO = new BookDTO
            {
                Id = Book.Id,
                Title = Book.Title
            };

            return bookDTO;
        }

        public IEnumerable<BookDTO> MapListBooksToDTO(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                BookDTO bookDTO = MapToDTO(book);
                bookDTOs.Add(bookDTO);
            }

            return bookDTOs;
        }
    }
}

