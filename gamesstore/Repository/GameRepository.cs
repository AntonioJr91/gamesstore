using gamesstore.Context;
using gamesstore.Domain;
using gamesstore.Interfaces;
using gamesstore.T;

namespace gamesstore.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context) { }
    }
}
