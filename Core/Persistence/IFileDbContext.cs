

namespace Core.Persistence
{
    public interface IFileDbContext : IDbContext
    {
        DbSet<Core.Entites.File> Files { get; }
    }
}
