using Domain.Core.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository
{

    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {

        private readonly SqlContext _context;
        public AuthorRepository(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

    }
    
}
