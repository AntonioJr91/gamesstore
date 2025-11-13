using gamesstore.Context;
using gamesstore.Domain;
using gamesstore.Interfaces;
using gamesstore.T;

namespace gamesstore.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
