namespace NEWSK8.Web.Data.Repositories
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using NEWSK8.Web.Helpers;
    using System.Linq;
    using System.Threading.Tasks;

    public class InteractionRepository : GenericRepository<Comments>, IInteractions
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public InteractionRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task<IQueryable<Comments>> GetCommentsAsync(string UserName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(UserName);
            if (user == null)
            {
                return null;
            }

            if (await this.userHelper.IsUserInRoleAsync(user, "standard"))
            {
                return this.context.Comments
                    .Include(o => o.Items)
                    .ThenInclude(i => i.Posts)
                    .OrderByDescending(o => o.NumberLikes);
            }

            return this.context.Comments
                .Include(o => o.Items)
                .ThenInclude(i => i.Posts)
                .Where(o => o.Users == user)
                .OrderByDescending(o => o.NumberLikes);
        }
    }
}