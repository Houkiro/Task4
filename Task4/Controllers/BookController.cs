using BLL.Interfaces;
using Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace Task4.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/books")]
    public class BookController : ControllerBase
    {
        private readonly IServiceManager _service;
        public BookController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks(int authorId)
        {
            var author = await _service.AuthorService.GetByIdAsync(authorId, trackChanges: false);

            var books = await _service.BookService.GetAllBooksForAuthorAsync(authorId, trackChanges: false);
            return Ok(books);
        }
        [HttpGet("{id:int}", Name = "GetBookForAuthor")]
        public async Task<IActionResult> GetBookByAuthorId(int authorId, int id)
        {
            var author = await _service.AuthorService.GetByIdAsync(authorId, trackChanges: false);

            var book = await _service.BookService.GetBooksForAuthorByIdAsync(authorId, id, trackChanges: false);

            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookForAuthor([FromBody] BookDtoWithoutId book, int authorId)
        {
            var author = await _service.AuthorService.GetByIdAsync(authorId, trackChanges: false);
            if (book is null)
                return BadRequest("BookDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var createdBook = await _service.BookService.CreateBookForAuthor(authorId, book, trackChanges: false);

            return CreatedAtAction("GetBookForAuthor", new { authorId = createdBook.Id, id = createdBook.Id }, createdBook);

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int authorId, int id, [FromBody] BookDtoWithoutId book)
        {
            if (book is null)
                return BadRequest("BookDto object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            await _service.BookService.UpdateBookForAuthorAsync(authorId, id, book, trackChanges: true);
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int authorId, int id)
        {
            await _service.BookService.DeleteBookForAuthorAsync(authorId, id, trackChanges: false);
            return NoContent();
        }
    }
}
