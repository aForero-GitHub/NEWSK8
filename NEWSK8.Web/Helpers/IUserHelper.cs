namespace NEWSK8.Web.Helpers
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using Models;
	using System.Threading.Tasks;

	public interface IUserHelper
	{
		Task<Users> GetUserByEmailAsync(string email);

		Task<IdentityResult> AddUserAsync(Users users, string password);

		Task<SignInResult> LoginAsync(LoginViewModel model);

		Task LogoutAsync();
	}

}
