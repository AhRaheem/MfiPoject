

namespace Core.Persistence
{
    public interface IDbContext
    {
        void Dispose();
        DbSet<T> Set<T>() where T : class;
        bool HasUnsavedChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
