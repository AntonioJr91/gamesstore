using gamesstore.Domain.DomainException;

namespace gamesstore.Domain
{
    public class Game
    {
        public Game(int id, string name, decimal price, DateTime publicationDate, Category category)
        {
            Id = id;
            Created_At = DateTime.UtcNow;
            IsValid(name, price, publicationDate);
            Category = category;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public DateTime Created_At { get; private set; }
        public DateTime PublicationDate { get; private set; }


        public int CategoryId { get; private set; }
        private Category? _category;
        public Category Category
        {
            get => _category ?? new Category("Others");
            private set => _category = value == null || string.IsNullOrEmpty(value.Name) ? new Category("Others") : value;
        }

        private void IsValid(string name, decimal price, DateTime publicationDate)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), $"[DomainException] Name field is required.");
            DomainValidationException.When(name.Length < 3 || name.Length > 50, $"[DomainException] Name must be between 3 and 50 characters long.");
            DomainValidationException.When(price < 0, $"[DomainException] Price cannot be negative.");
            DomainValidationException.When(price > 9999, $"[DomainException] Price cannot exceed 9999.");
            DomainValidationException.When(publicationDate.Year < 1970, $"[DomainException] Publication date cannot be earlier than 1970.");
            DomainValidationException.When(publicationDate > DateTime.UtcNow, $"[DomainException] Publication date cannot be in the future.");

            Name = name;
            Price = price;
            PublicationDate = publicationDate;
        }
    }
}
