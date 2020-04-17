namespace NEWSK8.Web.Helpers
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using System.Threading.Tasks;

	public class UserHelper : IUserHelper
	{
		private readonly UserManager<Users> userManager;

		public UserHelper(UserManager<Users> userManager)
		{
			this.userManager = userManager;
		}

		public async Task<IdentityResult> AddUserAsync(Users users, string password)
		{
			return await this.userManager.CreateAsync(users, password);
		}

		public async Task<Users> GetUserByEmailAsync(string email)
		{
			var users = await this.userManager.FindByEmailAsync(email);
			return users;
		}
	}

}
