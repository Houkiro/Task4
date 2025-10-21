using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAuthors([FromQuery] int? booksAfterYear = null)
        {
            if (booksAfterYear.HasValue)
            {
                var authorsWithBooksAfterYear = await _service.AuthorService.GetAuthorsWithBooksAfterYearAsync(booksAfterYear.Value);
                return Ok(authorsWithBooksAfterYear);
            }

            var authors = await _service.AuthorService.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id:int}", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _service.AuthorService.GetByIdAsync(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorModelDto author)
        {
            if (author is null) return BadRequest("Author object is null");
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var createdAuthor = await _service.AuthorService.CreateAsync(author);
            return CreatedAtRoute("AuthorById", new { id = createdAuthor.Id }, createdAuthor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorModelDto author)
        {
            if (author is null) return BadRequest("Author object is null");
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            await _service.AuthorService.UpdateAsync(id, author);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _service.AuthorService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("book-counts")]
        public async Task<IActionResult> GetAuthorsWithBookCount()
        {
            var authors = await _service.AuthorService.GetAuthorsWithBookCountAsync();
            return Ok(authors);
        }

        [HttpGet("search")]
        public async Task<IActionResult> FindAuthorsByName([FromQuery] string namePart)
        {
            var authors = await _service.AuthorService.FindAuthorsByNameAsync(namePart);
            return Ok(authors);
        }
    }
}
