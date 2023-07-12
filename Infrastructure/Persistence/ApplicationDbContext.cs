//Add-Migration Initial -o Persistence/Migrations -Context ApplicationDbContext


using Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
	{
        private readonly CurrentUserService _CurrentUserService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, CurrentUserService currentUserService) : base(options)
        {
            _CurrentUserService = currentUserService;
        }

        public DbSet<Gallery> Galleries => Set<Gallery>();
        public DbSet<GalleryItem> GalleryItems => Set<GalleryItem>();
        public DbSet<Partner> Partners => Set<Partner>();
        public DbSet<PartnerCategory> PartnerCategories => Set<PartnerCategory>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<PostParagraph> PostParagraphs => Set<PostParagraph>();
        public DbSet<PostAffiliateLaw> PostAffiliateLaws => Set<PostAffiliateLaw>();
        public DbSet<ProfileInfo> ProfileInfos => Set<ProfileInfo>();
        public DbSet<RelatedWebsite> RelatedWebsites => Set<RelatedWebsite>();




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            var setQueryFilterMethod = new Action<ModelBuilder>(SetQueryFilter<BaseEntity>)
                    .Method.GetGenericMethodDefinition();
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    if (entityType.BaseType == null && typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                    {
                        setQueryFilterMethod
                            .MakeGenericMethod(entityType.ClrType)
                            .Invoke(this, new object[] { modelBuilder });
                    }
                }
        }

        void SetQueryFilter<TEntity>(ModelBuilder modelBuilder)
            where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
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
