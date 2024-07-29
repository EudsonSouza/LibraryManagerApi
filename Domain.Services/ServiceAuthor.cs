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
    public class ServiceAuthor : ServiceBase<Author>, IServiceAuthor
    {
        public readonly IRepositoryAuthor _repositoryAuthor;

        public ServiceAuthor(IRepositoryAuthor repositoryAuthor)
            : base(repositoryAuthor)
        {
            _repositoryAuthor = repositoryAuthor;
        }
    }
}
