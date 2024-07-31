using Application.DTO;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Infrastructure.CrossCutting.Adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthorApplicationService : IAuthorApplicationService
{
        private readonly IAuthorService _serviceAuthor;
        private readonly IAuthorMapper _mapperAuthor;
     
        public AuthorApplicationService(IAuthorService serviceAuthor,
                                        IAuthorMapper mapperAuthor)
        {
            _serviceAuthor = serviceAuthor;
            _mapperAuthor = mapperAuthor;
        }


        public AuthorDTO Add(AuthorDTO obj)
        {
            var objAuthor = _mapperAuthor.MapToEntity(obj);
            var authorEntity = _serviceAuthor.Add(objAuthor);
            return _mapperAuthor.MapToDTO(authorEntity);
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            var objProdutos = _serviceAuthor.GetAll();
            return _mapperAuthor.MapListAuthorsToDTO(objProdutos);
        }

        public AuthorDTO GetById(int id)
        {
            var objAuthor = _serviceAuthor.GetById(id);
            return _mapperAuthor.MapToDTO(objAuthor);
        }

        public void Remove(AuthorDTO obj)
        {
            var objAuthor = _mapperAuthor.MapToEntity(obj);
            _serviceAuthor.Remove(objAuthor);
        }

        public AuthorDTO Update(AuthorDTO obj)
        {
            var objAuthor = _mapperAuthor.MapToEntity(obj);
            var authorEntity = _serviceAuthor.Update(objAuthor);
            return _mapperAuthor.MapToDTO(authorEntity);
        }
        public void Dispose()
        {
            _serviceAuthor.Dispose();
        }

    }
}
