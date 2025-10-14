using Core.Entities.Attributes.DTO;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTO
{
    public class BookDtoWithoutId
    {
        [Required(ErrorMessage = "Название обязательное поле")]
        [MaxLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public string? Title { get; set; }
        [Year]
        public int PublishedYear { get; set; }
    }
}