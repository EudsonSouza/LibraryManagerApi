using Domain.Core.Interfaces.Repositories;
using Domain.Core.Interfaces.Services;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new InvalidOperationException("An author with the same name already exists.");
            }

            return base.Add(author);
        }

    }
}