using Domain.Core.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

        public bool ExistsByName(string name)
        {
            return _context.Set<Author>().Any(a => a.Name == name);
        }

        public bool ExistsWithDifferentId(int? id, string name)
        {
            return _context.Set<Author>().Any(a => a.Name == name && a.Id != id);
        }

    }
    
}
