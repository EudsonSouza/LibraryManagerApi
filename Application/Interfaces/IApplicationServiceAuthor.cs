using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IApplicationServiceAuthor
    {
        AuthorDTO Add(AuthorDTO  obj);

        AuthorDTO GetById(int id);

        IEnumerable<AuthorDTO> GetAll();

        AuthorDTO Update(AuthorDTO obj);

        void Remove(AuthorDTO obj);

        void Dispose();
    }
}
