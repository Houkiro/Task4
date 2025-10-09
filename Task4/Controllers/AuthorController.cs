using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace Task4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _authorService.GetByIdAsync(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto author)
        {
            if (author == null) return BadRequest();

            var created = await _authorService.CreateAsync(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDto author)
        {
            if (author == null) return BadRequest();

            var updated = await _authorService.UpdateAsync(id, author);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var deleted = await _authorService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}