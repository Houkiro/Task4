using BLL.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class CreateBookModelDto : BookDto
    {
        [Required(ErrorMessage = "Название обязательное поле")]
        [MaxLength(100, ErrorMessage = "Название не может быть длиннее 100 символов")]
        public new string Title { get => base.Title; set => base.Title = value; }

        [Year]
        public new int PublishedYear { get => base.PublishedYear; set => base.PublishedYear = value; }
    }
}
