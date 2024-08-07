using Domain.Core.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository
{

    public class BookRepository : BaseRepository<Book>, IBookRepository
    {

        private readonly SqlContext _context;
        public BookRepository(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public bool ExistsByTitle(string title)
        {
            return _context.Set<Book>().Any(a => a.Title == title);
        }

        public bool ExistsWithDifferentId(int? id, string title)
        {
            return _context.Set<Book>().Any(a => a.Title == title && a.Id != id);
        }

    }
    
}
