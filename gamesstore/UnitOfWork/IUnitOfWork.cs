using gamesstore.Interfaces;

namespace gamesstore.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IGameRepository Games { get; }
        void SaveChanges();
    }
}
