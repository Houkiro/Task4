namespace Core.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(int bookId)
            : base ($"Книги с таким id: {bookId} не существует в базе данных")
        { }
    }
}