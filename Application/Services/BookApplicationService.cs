using Application.DTO;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Infrastructure.CrossCutting.Adapter.Interfaces;

namespace Application.Services
{
    public class BookApplicationService : IBookApplicationService
    {
        private readonly IBookService _serviceBook;
        private readonly IBookMapper _mapperBook;

        public BookApplicationService(IBookService serviceBook,
                                        IBookMapper mapperBook)
        {
            _serviceBook = serviceBook;
            _mapperBook = mapperBook;
        }


        public BookDTO Add(CreateBookDTO obj)
        {
            var objBook = _mapperBook.MapToEntity(obj);
            var bookEntity = _serviceBook.Add(objBook);
            return _mapperBook.MapToDTO(bookEntity);
        }

        public IEnumerable<BookDTO> GetAll()
        {
            var objProdutos = _serviceBook.GetAll();
            return _mapperBook.MapListBooksToDTO(objProdutos);
        }

        public BookDTO GetById(int id)
        {
            var objBook = _serviceBook.GetById(id);
            return _mapperBook.MapToDTO(objBook);
        }

        public void Remove(BookDTO obj)
        {
            var objBook = _mapperBook.MapToEntity(obj);
            _serviceBook.Remove(objBook);
        }

        public BookDTO Update(BookDTO obj)
        {
            var objBook = _mapperBook.MapToEntity(obj);
            var bookEntity = _serviceBook.Update(objBook);
            return _mapperBook.MapToDTO(bookEntity);
        }
        public void Dispose()
        {
            _serviceBook.Dispose();
        }

    }
}
