﻿using Application.DTO;
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
        public ActionResult<AuthorDTO> Post([FromBody] CreateAuthorDTO authorDTO)
        {
            try
            {
                if (authorDTO == null)
                    return BadRequest();

                var createdAuthor = _applicationServiceAuthor.Add(authorDTO);
                return Created(nameof(Get), createdAuthor);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpPut]
        public ActionResult<AuthorDTO> Put([FromBody] AuthorDTO authorDTO)
        {
            try
            {

                if (authorDTO == null)
                    return BadRequest();

                var updatedAuthorDTO = _applicationServiceAuthor.Update(authorDTO);
                return Ok(updatedAuthorDTO);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var author = _applicationServiceAuthor.GetById(id);
            if (author == null)
                return BadRequest();

            _applicationServiceAuthor.Remove(author);
            return Ok("Author deleted successfully!");
        }
    }
}
