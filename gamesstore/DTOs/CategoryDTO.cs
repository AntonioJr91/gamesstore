using System.ComponentModel.DataAnnotations;

namespace gamesstore.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters long")]
        public string Name { get; set; } = string.Empty;
    }
}
