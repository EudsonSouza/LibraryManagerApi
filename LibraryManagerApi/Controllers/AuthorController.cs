using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorApplicationService _applicationServiceAuthor;

        public AuthorController(ILogger<AuthorController> logger,
                                IAuthorApplicationService applicationServiceAuthor)
        {
            _logger = logger;
            _applicationServiceAuthor = applicationServiceAuthor;
        }
    

        [HttpGet(Name = "GetAuthor")]
        public ActionResult<IEnumerable<AuthorDTO>> Get()
        {
            return Ok(_applicationServiceAuthor.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDTO> Get(int id)
        {
            return Ok(_applicationServiceAuthor.GetById(id));
        }

        [HttpPost]
        public ActionResult<AuthorDTO> Post([FromBody] AuthorDTO authorDTO)
        {
            if (authorDTO == null)
                return NotFound();

            var createdAuthor = _applicationServiceAuthor.Add(authorDTO);
            return Created(nameof(Get), createdAuthor);
        }

        [HttpPut]
        public ActionResult<AuthorDTO> Put([FromBody] AuthorDTO authorDTO)
        {
            if (authorDTO == null)
                return NotFound();

            var updatedAuthorDTO = _applicationServiceAuthor.Update(authorDTO);
            return Ok(updatedAuthorDTO);
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] AuthorDTO authorDTO)
        {
            if (authorDTO == null)
                return NotFound();

            _applicationServiceAuthor.Remove(authorDTO);
            return Ok("Author deleted successfully!");
        }
    }
}
