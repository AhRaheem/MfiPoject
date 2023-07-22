

using Infrastructure.DtoValidators.AffiliateLaw;
using Infrastructure.DtoValidators.Paragraph;
using Infrastructure.DtoValidators.Partner;
using Infrastructure.DtoValidators.PartnerCategory;
using Infrastructure.DtoValidators.Post;
using Infrastructure.DtoValidators.ProfileInfo;
using Infrastructure.DtoValidators.RelatedWebsite;
using Infrastructure.DtoValidators.User;
using Infrastructure.Helpers;
using Microsoft.Extensions.Hosting.Internal;
using System;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<FileDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FileDbConnection"));
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IFileDbContext>(provider => provider.GetRequiredService<FileDbContext>());

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 4;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
			});

			services.AddIdentity<ApplicationUser, IdentityRole>(optn =>
            {
                optn.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

			// repos
            services.AddScoped<IGalleryRepository, GalleryRepository>();
			services.AddScoped<IPartnerRepository, PartnerRepository>();
			services.AddScoped<IPartnerCategoryRepository, PartnerCategoryRepository>();
			//services.AddScoped<IPostRepository, PostRepository>();
			services.AddScoped<IProfileInfoRepository, ProfileInfoRepository>();
			services.AddScoped<IRelatedWebsiteRepository, RelatedWebsiteRepository>();

			// services
            services.AddScoped<IFileService, FileService>();
			services.AddScoped<IGalleryService, GalleryService>();
			services.AddScoped<IPartnerCategoryService, PartnerCategoryService>();
			services.AddScoped<IPartnerService, PartnerService>();
			//services.AddScoped<IPostService, PostService>();
			services.AddScoped<IProfileInfoService, ProfileInfoService>();
			services.AddScoped<IRelatedWebsiteService, RelatedWebsiteService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<CurrentUserService>();

            // validators
            services.AddScoped<IValidator<GalleryCreateDto>, GalleryCreateDtoValidator>();
            services.AddScoped<IValidator<GalleryUpdateDto>, GalleryUpdateDtoValidator>();
            services.AddScoped<IValidator<GalleryItemCreateDto>, GalleryItemCreateDtoValidator>();
			services.AddScoped<IValidator<PartnerCreateDto>, PartnerCreateDtoValidator>();
			services.AddScoped<IValidator<PartnerUpdateDto>, PartnerUpdateDtoValidator>();
			services.AddScoped<IValidator<PartnerCategoryCreateDto>, PartnerCategoryCreateDtoValidator>();
			services.AddScoped<IValidator<PartnerCategoryUpdateDto>, PartnerCategoryUpdateDtoValidator>();
			services.AddScoped<IValidator<ProfileInfoCreateDto>, ProfileInfoCreateDtoValidator>();
			services.AddScoped<IValidator<ProfileInfoUpdateDto>, ProfileInfoUpdateDtoValidator>();
			services.AddScoped<IValidator<RelatedWebsiteCreateDto>, RelatedWebsiteCreateDtoValidator>();
			services.AddScoped<IValidator<RelatedWebsiteUpdateDto>, RelatedWebsiteUpdateDtoValidator>();
			//services.AddScoped<IValidator<PostCreateDto>, PostCreateDtoValidator>();
			//services.AddScoped<IValidator<PostParagraphCreateDto>, ParagraphCreateDtoValidator>();
			//services.AddScoped<IValidator<PostAffiliateLawCreateDto>, AffiliateLawCreateDtoValidator>();
			//services.AddScoped<IValidator<PostUpdateDto>, PostUpdateDtoValidator>();
			//services.AddScoped<IValidator<PostAffiliateLawUpdateDto>, AffiliateLawUpdateDtoValidator>();
			//services.AddScoped<IValidator<PostParagraphUpdateDto>, ParagraphUpdateDtoValidator>();
			services.AddScoped<IValidator<UserCreateDto>, UserCreateDtoValidator>();
			services.AddScoped<IValidator<LoginViewModel>, UserLoginValidator>();

            return services;
        }
    }
}
