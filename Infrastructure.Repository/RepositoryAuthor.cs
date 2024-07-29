using Domain.Core.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository
{

    public class RepositoryAuthor : RepositoryBase<Author>, IRepositoryAuthor
    {

        private readonly SqlContext _context;
        public RepositoryAuthor(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

    }
    
}
