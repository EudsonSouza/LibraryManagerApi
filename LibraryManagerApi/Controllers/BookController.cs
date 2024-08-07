using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookApplicationService _applicationServiceBook;

        public BookController(ILogger<BookController> logger,
                                IBookApplicationService applicationServiceBook)
        {
            _logger = logger;
            _applicationServiceBook = applicationServiceBook;
        }
    

        [HttpGet(Name = "GetBook")]
        public ActionResult<IEnumerable<BookDTO>> Get()
        {
            return Ok(_applicationServiceBook.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> Get(int id)
        {
            return Ok(_applicationServiceBook.GetById(id));
        }

        [HttpPost]
        public ActionResult<BookDTO> Post([FromBody] CreateBookDTO bookDTO)
        {
            try
            {
                if (bookDTO == null)
                    return BadRequest();

                var createdBook = _applicationServiceBook.Add(bookDTO);
                return Created(nameof(Get), createdBook);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult<BookDTO> Put([FromBody] BookDTO bookDTO)
        {
            try
            {

                if (bookDTO == null)
                    return BadRequest();

                var updatedBookDTO = _applicationServiceBook.Update(bookDTO);
                return Ok(updatedBookDTO);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _applicationServiceBook.GetById(id);
            if (book == null)
                return BadRequest();

            _applicationServiceBook.Remove(book);
            return Ok("Book deleted successfully!");
        }
    }
}
