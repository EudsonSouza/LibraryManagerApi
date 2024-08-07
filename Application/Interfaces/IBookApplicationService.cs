using Application.DTO;

namespace Application.Interfaces
{
    public interface IBookApplicationService
    {
        BookDTO Add(CreateBookDTO  book);

        BookDTO GetById(int id);

        IEnumerable<BookDTO> GetAll();

        BookDTO Update(BookDTO book);

        void Remove(BookDTO book);

        void Dispose();
    }
}
