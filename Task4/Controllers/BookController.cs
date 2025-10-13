using BLL.Interfaces;
using Core.Entities.Model;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;

namespace Task4.Controllers
{
    [ApiController]
    [Route("api/authors")]
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
            var author = await _service.AuthorService.GetByIdAsync(authorId);
            if(author is null)
                return NotFound();
            var books = await _service.BookService.GetAllBooksForAuthorAsync(authorId);
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookByAuthorId(int authorId, int id)
        {
            var author = await _service.AuthorService.GetByIdAsync(authorId);
            if(author is null )
                return NotFound();
            var book = await _service.BookService.GetBooksForAuthorByIdAsync(authorId, id);
            if(book is null )
                return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookForAuthor([FromBody] BookDto book, int authorId)
        {
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var author = await _service.AuthorService.GetByIdAsync(authorId);

            if( author is null )
                return NotFound();

            if (book is null)
                return NotFound();

            var created = await _service.BookService.CreateBookForAuthor(authorId, book);

            ModelState.ClearValidationState(nameof(Book));
            if (!TryValidateModel(book, nameof(Book)))
                return UnprocessableEntity(ModelState);

            return CreatedAtAction(nameof(GetBookByAuthorId), new { authorId = authorId, id = created.Id }, created);

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int authorId, int id, [FromBody] BookDto book)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var author = await _service.AuthorService.GetByIdAsync(authorId);
            if (author is null)
                return NotFound();
            if(book is null)
                return NotFound();
            var update = await _service.BookService.UpdateBookForAuthorAsync(authorId, id, book);
            if(update is null )
                return NotFound();

            ModelState.ClearValidationState(nameof(Book));
            if (!TryValidateModel(book, nameof(Book)))
                return UnprocessableEntity(ModelState);

            return Ok(update);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int authorId, int id)
        {
            var author = await _service.AuthorService.GetByIdAsync(authorId);
            if(author is null)
                return NotFound();
            var deleted = await _service.BookService.DeleteBookForAuthorAsync(authorId, id);
            if(!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
