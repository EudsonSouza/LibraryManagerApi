using Domain.Models;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        bool ExistsByTitle(string title);
        bool ExistsWithDifferentId(int? id, string title);
    }
}
