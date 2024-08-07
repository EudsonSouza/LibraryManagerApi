using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        public readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
            : base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public override Book Add(Book book)
        {
            if (_bookRepository.ExistsByTitle(book.Title))
            {
                ThrowNameAlreadyExistsException();
            }
            return base.Add(book);
        }
        public override Book Update(Book book)
        {
            if (_bookRepository.ExistsWithDifferentId(book.Id, book.Title))
            {
                ThrowNameAlreadyExistsException();
            }
            return base.Update(book);
        }

        private void ThrowNameAlreadyExistsException()
        {
            throw new InvalidOperationException("An book with the same name already exists.");
        }
    }
}