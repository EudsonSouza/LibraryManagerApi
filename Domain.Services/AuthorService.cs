using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        public readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
            : base(authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public override Author Add(Author author)
        {
            if (_authorRepository.ExistsByName(author.Name))
            {
                ThrowNameAlreadyExistsException();
            }
            return base.Add(author);
        }
        public override Author Update(Author author)
        {
            if (_authorRepository.ExistsWithDifferentId(author.Id, author.Name))
            {
                ThrowNameAlreadyExistsException();
            }
            return base.Update(author);
        }

        private void ThrowNameAlreadyExistsException()
        {
            throw new InvalidOperationException("An author with the same name already exists.");
        }
    }
}