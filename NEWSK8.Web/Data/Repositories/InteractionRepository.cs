namespace NEWSK8.Web.Data.Repositories
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using NEWSK8.Web.Helpers;
    using System.Linq;
    using System.Threading.Tasks;

    public class InteractionRepository : GenericRepository<Posts>, IInteractions
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public InteractionRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }
        public async Task<IQueryable<Posts>> GetPostsAsync(string UserName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(UserName);
            if (user == null)
            {
                return null;
            }

            return this.context.Posts
                .Include(o => o.Post)
                .Where(o => o.Users == user)
                .OrderByDescending(o => o.Data);
        }
    }
}