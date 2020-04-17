

namespace NEWSK8.Web.Helpers
{
	using System.Threading.Tasks;
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;

	public interface IUserHelper
	{
		Task<Users> GetUserByEmailAsync(string email);

		Task<IdentityResult> AddUserAsync(Users users, string password);
	}

}
