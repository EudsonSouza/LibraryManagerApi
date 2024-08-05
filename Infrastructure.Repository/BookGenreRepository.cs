using Domain.Core.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository
{

    public class BookGenreRepository : BaseRepository<BookGenre>, IBookGenreRepository
    {

        private readonly SqlContext _context;
        public BookGenreRepository(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public bool ExistsByName(string name)
        {
            return _context.Set<BookGenre>().Any(a => a.Name == name);
        }

        public bool ExistsWithDifferentId(int? id, string name)
        {
            return _context.Set<BookGenre>().Any(a => a.Name == name && a.Id != id);
        }

    }
    
}
