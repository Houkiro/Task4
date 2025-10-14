using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace Task4.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthorController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _service.AuthorService.GetAllAsync(trackChanges: false);
            return Ok(authors);
        }

        [HttpGet("{id:int}", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _service.AuthorService.GetByIdAsync(id, trackChanges: false);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDtoWithoutId author)
        {
            if (author is null)
                return BadRequest("AuthorDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdAuthor = await _service.AuthorService.CreateAsync(author);
            return CreatedAtRoute("AuthorById", new {id = createdAuthor.Id}, createdAuthor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDtoWithoutId author)
        {
            if (author is null)
                return BadRequest("AuthorDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _service.AuthorService.UpdateAsync(id, author, trackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _service.AuthorService.DeleteAsync(id, trackChanges: false);

            return NoContent();
        }

    }
}