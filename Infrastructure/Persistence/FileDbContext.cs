

using Infrastructure.Helpers;

namespace Infrastructure.Persistence
{
    public class FileDbContext : DbContext, IFileDbContext
    {
        private readonly CurrentUserService _CurrentUserService;
        public FileDbContext(DbContextOptions<FileDbContext> options, CurrentUserService currentUserService) : base(options)
        {
        }

        public DbSet<Core.Entites.File> Files => Set<Core.Entites.File>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return await base.SaveChangesAsync(cancellationToken);
        }


        private void OnBeforeSaving()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added
                || e.State == EntityState.Modified || e.State == EntityState.Deleted));


            foreach (var entry in entries)
            {
                var trackable = ((BaseEntity)entry.Entity);
                var UtcNow = DateTime.Now;
                switch (entry.State)
                {

                    case EntityState.Added:
                        trackable.CreatedOn = UtcNow;
                        trackable.UpdatedOn = UtcNow;
                        trackable.CreatedById = _CurrentUserService.GetUserId();
                        break;

                    case EntityState.Modified:
                        trackable.UpdatedOn = UtcNow;
                        trackable.UpdatedById = _CurrentUserService.GetUserId();
                        break;

                    case EntityState.Deleted:
                        trackable.IsDeleted = true;
                        trackable.DeletedOn = UtcNow;
                        trackable.DeletedById = _CurrentUserService.GetUserId();
                        break;
                }
            }
        }

        public bool HasUnsavedChanges()
        {
            return this.ChangeTracker.HasChanges();
        }
    }
}
