namespace NEWSK8.Web.Data.Repositories
{
    using Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IInteractions : IGenericRepository<Comments>
    {
        Task<IQueryable<Comments>> GetCommentsAsync(string UserName);
    }
}
