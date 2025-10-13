using BLL.Interfaces;
using Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace Task4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            var authors = await _service.AuthorService.GetAllAsync();
            return Ok(authors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _service.AuthorService.GetByIdAsync(id);
            if (author is null) 
                return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto author)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (author is null) 
                return NotFound();

            var created = await _service.AuthorService.CreateAsync(author);

            ModelState.ClearValidationState(nameof(Author));
            if (!TryValidateModel(author, nameof(Author)))
                return UnprocessableEntity(ModelState);

            return CreatedAtAction(nameof(GetAuthorById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorDto author)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            if (author is null) 
                return NotFound();

            var updated = await _service.AuthorService.UpdateAsync(id, author);
            if (updated is null)
                return NotFound();

            ModelState.ClearValidationState(nameof(Author));
            if (!TryValidateModel(author, nameof(Author)))
                return UnprocessableEntity(ModelState);

            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var deleted = await _service.AuthorService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}