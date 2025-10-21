using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            var books = await _service.BookService.GetAllBooksForAuthorAsync(authorId);
            return Ok(books);
        }

        [HttpGet("{id:int}", Name = "GetBookForAuthor")]
        public async Task<IActionResult> GetBookById(int authorId, int id)
        {
            var book = await _service.BookService.GetBooksForAuthorByIdAsync(authorId, id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookForAuthor(int authorId, [FromBody] CreateBookModelDto book)
        {
            if (book is null) return BadRequest("Book object is null");
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            var createdBook = await _service.BookService.CreateBookForAuthor(authorId, book);
            return CreatedAtRoute("GetBookForAuthor", new { authorId = authorId, id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int authorId, int id, [FromBody] UpdateBookModelDto book)
        {
            if (book is null) return BadRequest("Book object is null");
            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

            await _service.BookService.UpdateBookForAuthorAsync(authorId, id, book);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int authorId, int id)
        {
            await _service.BookService.DeleteBookForAuthorAsync(authorId, id);
            return NoContent();
        }
    }
}
