using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test4.Attributes;

namespace Shared.DTO
{
    public class AuthorWithBookCountDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BookCount { get; set; }
    }
}
