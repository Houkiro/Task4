using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Model
{
    public class Book
    {
        [Column("BookId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Название обязательное поле")]
        [MaxLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
