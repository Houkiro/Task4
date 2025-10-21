namespace BLL.Exceptions
{
    public sealed class AuthorNotFoundException : NotFoundException
    {
        public AuthorNotFoundException(int authorId)
            : base($"Автор с id: {authorId} не существует в базе данных.")
        {
        }
    }
}