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
        private readonly IApplicationServiceAuthor _applicationServiceAuthor;

        public AuthorController(ILogger<AuthorController> logger,
                                IApplicationServiceAuthor applicationServiceAuthor)
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
        public ActionResult Post([FromBody] AuthorDTO authorDTO)
        {
            if (authorDTO == null)
                return NotFound();

            _applicationServiceAuthor.Add(authorDTO);
            return Ok("Author created successfully!");
        }

        [HttpPut]
        public ActionResult Put([FromBody] AuthorDTO authorDTO)
        {
            if (authorDTO == null)
                return NotFound();

            _applicationServiceAuthor.Update(authorDTO);
            return Ok("Author updated successfully!");
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
