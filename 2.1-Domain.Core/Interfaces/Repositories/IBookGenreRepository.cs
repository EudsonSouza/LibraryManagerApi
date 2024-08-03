using Domain.Models;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IBookGenreRepository : IBaseRepository<BookGenre>
    {
        bool ExistsByName(string name);

        bool ExistsWithDifferentId(int? id, string name);
    }
}
