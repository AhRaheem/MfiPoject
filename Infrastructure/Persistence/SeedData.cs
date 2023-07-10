using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
	public class SeedData
	{
		public static async Task InitializeAsync(IServiceProvider service)
		{
			var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
			await AddRolesToDatabase(roleManager);

			var context = service.GetRequiredService<UserManager<ApplicationUser>>();
			await AddAdminToDatabase(context);
		}

		protected static async Task AddAdminToDatabase(UserManager<ApplicationUser> UsrMngr)
		{
			var AdminUsr = await UsrMngr.FindByEmailAsync("Admin@mail.com");
			if (AdminUsr is null) 
			{
				var user = new ApplicationUser()
				{
					Id = Guid.NewGuid().ToString(),
					UserName = ("Admin@mail.com"),
					NormalizedUserName = ("Admin@mail.com").ToUpper(),
					Email = ("Admin@mail.com"),
					NormalizedEmail = ("Admin@mail.com").ToUpper(),
					EmailConfirmed = true,
					LockoutEnabled = false,
					IsAdmin = true
				};

				await UsrMngr.CreateAsync(user,"Password@123");
				await UsrMngr.AddToRoleAsync(user, "Admin");
			}
		}

		protected static async Task AddRolesToDatabase(RoleManager<IdentityRole> roleManager)
		{
			var enumRoles = Enum.GetValues(typeof(RolesType));
			foreach (var item in enumRoles)
			{
				var role = item.ToString();
				var ExitsRole = await roleManager.FindByNameAsync(role);
				if(ExitsRole is null)
					await roleManager.CreateAsync(new IdentityRole(role));
			}
		}
	}
}
