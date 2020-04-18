namespace NEWSK8.Web.Helpers
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using NEWSK8.Web.Models;
	using System.Threading.Tasks;

	public class UserHelper : IUserHelper
	{
		private readonly UserManager<Users> userManager;
		private readonly SignInManager<Users> signInManager;

		public UserHelper(
			UserManager<Users> userManager,
			SignInManager<Users> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
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

		public async Task<SignInResult> LoginAsync(LoginViewModel model)
		{
			return await this.signInManager.PasswordSignInAsync(
			model.UserName,
			model.Password,
			model.RememberMe,
			false);
		}

		public async Task LogoutAsync()
		{
			await this.signInManager.SignOutAsync();

		}
	}

}
