using Application.DTO;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Infrastructure.CrossCutting.Adapter.Interfaces;

namespace Application.Services
{
    public class BookGenreApplicationService : IBookGenreApplicationService
{
        private readonly IBookGenreService _serviceBookGenre;
        private readonly IBookGenreMapper _mapperBookGenre;
     
        public BookGenreApplicationService(IBookGenreService serviceBookGenre,
                                        IBookGenreMapper mapperBookGenre)
        {
            _serviceBookGenre = serviceBookGenre;
            _mapperBookGenre = mapperBookGenre;
        }


        public BookGenreDTO Add(CreateBookGenreDTO obj)
        {
            var objBookGenre = _mapperBookGenre.MapToEntity(obj);
            var bookGenreEntity = _serviceBookGenre.Add(objBookGenre);
            return _mapperBookGenre.MapToDTO(bookGenreEntity);
        }

        public IEnumerable<BookGenreDTO> GetAll()
        {
            var objProdutos = _serviceBookGenre.GetAll();
            return _mapperBookGenre.MapListBookGenresToDTO(objProdutos);
        }

        public BookGenreDTO GetById(int id)
        {
            var objBookGenre = _serviceBookGenre.GetById(id);
            return _mapperBookGenre.MapToDTO(objBookGenre);
        }

        public void Remove(BookGenreDTO obj)
        {
            var objBookGenre = _mapperBookGenre.MapToEntity(obj);
            _serviceBookGenre.Remove(objBookGenre);
        }

        public BookGenreDTO Update(BookGenreDTO obj)
        {
            var objBookGenre = _mapperBookGenre.MapToEntity(obj);
            var bookGenreEntity = _serviceBookGenre.Update(objBookGenre);
            return _mapperBookGenre.MapToDTO(bookGenreEntity);
        }
        public void Dispose()
        {
            _serviceBookGenre.Dispose();
        }

    }
}
