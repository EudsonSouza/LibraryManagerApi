using Application.DTO;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationServiceAuthor : IApplicationServiceAuthor
{
        private readonly IServiceAuthor _serviceAuthor;
        private readonly IMapperAuthor _mapperAuthor;
     
        public ApplicationServiceAuthor(IServiceAuthor ServiceAuthor,
                                        IMapperAuthor MapperAuthor)
        {
            _serviceAuthor = ServiceAuthor;
            _mapperAuthor = MapperAuthor;
        }


        public void Add(AuthorDTO obj)
        {
            var objAuthor = _mapperAuthor.MapperToEntity(obj);
            _serviceAuthor.Add(objAuthor);
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            var objProdutos = _serviceAuthor.GetAll();
            return _mapperAuthor.MapperListAuthors(objProdutos);
        }

        public AuthorDTO GetById(int id)
        {
            var objAuthor = _serviceAuthor.GetById(id);
            return _mapperAuthor.MapperToDTO(objAuthor);
        }

        public void Remove(AuthorDTO obj)
        {
            var objAuthor = _mapperAuthor.MapperToEntity(obj);
            _serviceAuthor.Remove(objAuthor);
        }

        public void Update(AuthorDTO obj)
        {
            var objAuthor = _mapperAuthor.MapperToEntity(obj);
            _serviceAuthor.Update(objAuthor);
        }
        public void Dispose()
        {
            _serviceAuthor.Dispose();
        }

    }
}
