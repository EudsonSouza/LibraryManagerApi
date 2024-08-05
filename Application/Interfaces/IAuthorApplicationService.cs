using Application.DTO;

namespace Application.Interfaces
{
    public interface IAuthorApplicationService
    {
        AuthorDTO Add(CreateAuthorDTO  obj);

        AuthorDTO GetById(int id);

        IEnumerable<AuthorDTO> GetAll();

        AuthorDTO Update(AuthorDTO obj);

        void Remove(AuthorDTO obj);

        void Dispose();
    }
}
