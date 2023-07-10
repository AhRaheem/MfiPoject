
using FluentValidation.AspNetCore;
using Infrastructure.Helpers;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();


try
{
    Translator.LoadLanguageFiles(builder.Environment.WebRootPath);
}
catch (Exception e) { }

var app = builder.Build();

var scope = app.Services.CreateScope();

try
{
	var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	var FileDbContext = scope.ServiceProvider.GetRequiredService<FileDbContext>();
	dbContext.Database.Migrate();
	FileDbContext.Database.Migrate();
}
catch (Exception ex)
{
	app.Logger.LogError(ex, ex.Message);
}

var accessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
Translator.SetHttpContextAccessor(accessor);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=account}/{action=login}/{id?}");

// Seed Data To Database
try
{
	await SeedData.InitializeAsync(scope.ServiceProvider);
}
catch (Exception ex)
{
	app.Logger.LogError(ex, ex.Message);
}


scope.Dispose();
app.Run();
