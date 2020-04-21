using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NEWSK8.Web.Data.Repositories;
using System.Threading.Tasks;

namespace NEWSK8.Web.Controllers
{
    [Authorize]
    public class InteractionsController : Controller
    {
        private readonly IInteractions interactions;

        public InteractionsController(IInteractions interactions)
        {
            this.interactions = interactions;
        }

        public async Task<IActionResult> Index()
        {
            ;
            var model = await interactions.GetPostsAsync(this.User.Identity.Name);
            return View(model);
        }
    }
}
