namespace BLL.DTO
{
    public class BookResponseDto : BookDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
    }
}