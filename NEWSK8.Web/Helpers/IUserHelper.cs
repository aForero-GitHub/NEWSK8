﻿namespace NEWSK8.Web.Helpers
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

		Task<IdentityResult> UpdateUserAsync(Users user);

		Task<IdentityResult> ChangePasswordAsync(Users user, string oldPassword, string newPassword);

		Task<SignInResult> ValidatePasswordAsync(Users user, string password);

		Task CheckRoleAsync(string roleName);

		Task AddUserToRoleAsync(Users users, string rolName);

		Task<bool> IsUserInRoleAsync(Users users, string roleName);

		Task<string> GenerateEmailConfirmationTokenAsync(Users users);

		Task<IdentityResult> ConfirmEmailAsync(Users users, string token);

		Task<Users> GetUsersByIdAsync(string userId);
	}	

}
