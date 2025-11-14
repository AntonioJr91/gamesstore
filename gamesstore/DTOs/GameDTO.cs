using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamesstore.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters long")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 9999, ErrorMessage = "Price must be between 0 and 9999.")]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created_At { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublicationDate { get; set; }

        public int CategoryId { get; set; }
    }
}
