using gamesstore.Context;
using gamesstore.Interfaces;

namespace gamesstore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories { get; }
        public IGameRepository Games { get; }

        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context, ICategoryRepository categories, IGameRepository games)
        {
            _context = context;
            Categories = categories;
            Games = games;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
