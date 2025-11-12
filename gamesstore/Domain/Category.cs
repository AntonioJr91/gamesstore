using gamesstore.Domain.DomainException;

namespace gamesstore.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; private set; } = string.Empty;

        public Category(string name)
        {
            IsValid(name);
        }

        private void IsValid(string name)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), $"[DomainException] Name field is required.");
            DomainValidationException.When(name.Length < 3 || name.Length > 50, $"[DomainException] Name must be between 3 and 50 characters long.");

            Name = name;
        }
    }
}
