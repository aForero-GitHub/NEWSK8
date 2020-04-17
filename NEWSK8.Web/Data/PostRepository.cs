namespace NEWSK8.Web.Data
{
	using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

	public class PostRepository : GenericRepository<Posts>, IPostRepository
	{
		private readonly DataContext context;

		public PostRepository(DataContext context) : base(context)
		{
			this.context = context;
		}

		public IQueryable GetAllWithUsers()
		{
			return this.context.Posts.Include(p => p.Users);
		}
	}

}
