using gamesstore.Domain.DomainException;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace gamesstore.Domain
{
    public class Category
    {
        public Category() { }

        public Category(string name)
        {
            IsValid(name);
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters long")]
        public string Name { get; private set; } = string.Empty;

        public ICollection<Game>? Games { get; private set; }

        private void IsValid(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), $"[DomainException] Name field is required.");
            DomainValidationException.When(name.Length < 3 || name.Length > 50, $"[DomainException] Name must be between 3 and 50 characters long.");

            Name = name;
            Games = new Collection<Game>();
        }
    }
}
