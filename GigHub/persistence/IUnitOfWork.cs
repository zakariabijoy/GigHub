using GigHub.Repositories;

namespace GigHub.persistence
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; }
        void Complete();
    }
}