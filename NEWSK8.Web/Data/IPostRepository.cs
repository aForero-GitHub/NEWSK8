namespace NEWSK8.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IPostRepository : IGenericRepository<Posts>
    {
        IQueryable GetAllWithUsers();
    }

}
