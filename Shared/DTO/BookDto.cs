using Core.Entities.Attributes.DTO;
using Core.Entities.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DTO
{
    public class BookDto
    {
        [Key]
        [Column("BookId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Название обязательное поле")]
        [MaxLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string? Title { get; set; }
        [Year]
        public int PublishedYear { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
    }
}