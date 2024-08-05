using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookGenreController : ControllerBase
    {
        private readonly ILogger<BookGenreController> _logger;
        private readonly IBookGenreApplicationService _applicationServiceBookGenre;

        public BookGenreController(ILogger<BookGenreController> logger,
                                IBookGenreApplicationService applicationServiceBookGenre)
        {
            _logger = logger;
            _applicationServiceBookGenre = applicationServiceBookGenre;
        }
    

        [HttpGet(Name = "GetBookGenre")]
        public ActionResult<IEnumerable<BookGenreDTO>> Get()
        {
            return Ok(_applicationServiceBookGenre.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BookGenreDTO> Get(int id)
        {
            return Ok(_applicationServiceBookGenre.GetById(id));
        }

        [HttpPost]
        public ActionResult<BookGenreDTO> Post([FromBody] CreateBookGenreDTO bookGenreDTO)
        {
            try
            {
                if (bookGenreDTO == null)
                    return BadRequest();

                var createdBookGenre = _applicationServiceBookGenre.Add(bookGenreDTO);
                return Created(nameof(Get), createdBookGenre);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult<BookGenreDTO> Put([FromBody] BookGenreDTO bookGenreDTO)
        {
            try
            {

                if (bookGenreDTO == null)
                    return BadRequest();

                var updatedBookGenreDTO = _applicationServiceBookGenre.Update(bookGenreDTO);
                return Ok(updatedBookGenreDTO);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var bookGenre = _applicationServiceBookGenre.GetById(id);
            if (bookGenre == null)
                return BadRequest();

            _applicationServiceBookGenre.Remove(bookGenre);
            return Ok("BookGenre deleted successfully!");
        }
    }
}
