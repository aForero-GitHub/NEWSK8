using Microsoft.AspNetCore.Identity;
using NEWSK8.Web.Data;
using NEWSK8.Web.Data.Entities;
using NEWSK8.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

public class SeedDb
{
    private readonly DataContext context;
    private readonly IUserHelper userHelper;

    //private Random random;

    public SeedDb(DataContext context, IUserHelper userHelper)
    {
        this.context = context;
        this.userHelper = userHelper;
        //this.random = new Random();
    }

    public async Task SeedAsync()
    {
        await this.context.Database.EnsureCreatedAsync();

        await this.userHelper.CheckRoleAsync("Company");
        await this.userHelper.CheckRoleAsync("standard");

        var user = await this.userHelper.GetUserByEmailAsync("adavidforero@ucundinamarca.edu.co");

        if (user == null)
        {
            user = new Users
            {
                FirstName = "Andres",
                LastName = "Forero",
                Email = "adavidforero@ucundinamarca.edu.co",
                UserName = "AForero",
                PhoneNumber = "3196535245"
            };

            var result = await this.userHelper.AddUserAsync(user, "1000239960");
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create the user in seeder");
            }

            await this.userHelper.AddUserToRoleAsync(user, "standard");
        }

        var isInRole = await this.userHelper.IsUserInRoleAsync(user, "standard");
        if(!isInRole)
        {
            await this.userHelper.AddUserToRoleAsync(user, "standard");
        }

        if (!this.context.Posts.Any())
        {
            this.AddPost("Welcome to NEWSK8", user);
            await this.context.SaveChangesAsync();
        }
    }
    private void AddPost(string text, Users users)
    {
        this.context.Posts.Add(new Posts
        {
            Text = text,
            Users = users
        });
    }
}

