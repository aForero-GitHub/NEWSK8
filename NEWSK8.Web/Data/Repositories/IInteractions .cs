namespace NEWSK8.Web.Data.Repositories
{
    using Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IInteractions : IGenericRepository<Posts>
    {
        Task<IQueryable<Posts>> GetPostsAsync(string UserName);
    }
}
