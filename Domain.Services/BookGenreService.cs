using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class BookGenreService : BaseService<BookGenre>, IBookGenreService
    {
        public readonly IBookGenreRepository _bookGenreRepository;

        public BookGenreService(IBookGenreRepository bookGenreRepository)
            : base(bookGenreRepository)
        {
            _bookGenreRepository = bookGenreRepository;
        }

        public override BookGenre Add(BookGenre bookGenre)
        {
            if (_bookGenreRepository.ExistsByName(bookGenre.Name))
            {
                ThrowNameAlreadyExistsException();
            }
            return base.Add(bookGenre);
        }
        public override BookGenre Update(BookGenre bookGenre)
        {
            if (_bookGenreRepository.ExistsWithDifferentId(bookGenre.Id, bookGenre.Name))
            {
                ThrowNameAlreadyExistsException();
            }
            return base.Update(bookGenre);
        }

        private void ThrowNameAlreadyExistsException()
        {
            throw new InvalidOperationException("A book genre with the same name already exists.");
        }
    }
}














