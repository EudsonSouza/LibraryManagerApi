using Application.DTO;

namespace Application.Interfaces
{
    public interface IBookGenreApplicationService
    {
        BookGenreDTO Add(CreateBookGenreDTO  bookGenre);

        BookGenreDTO GetById(int id);

        IEnumerable<BookGenreDTO> GetAll();

        BookGenreDTO Update(BookGenreDTO bookGenre);

        void Remove(BookGenreDTO bookGenre);

        void Dispose();
    }
}
