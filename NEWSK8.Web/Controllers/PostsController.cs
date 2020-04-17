namespace NEWSK8.Web.Controllers
{
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using NEWSK8.Web.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostsController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly IUserHelper userHelper;

        public PostsController(IPostRepository postRepository, IUserHelper userHelper)
        {
            this.postRepository = postRepository;
            this.userHelper = userHelper;
        }

        // GET: Posts
        public IActionResult Index()
        {
            return View(this.postRepository.GetAll().OrderBy(p => p.Data));
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await this.postRepository.GetByIdAsync(id.Value);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";


                    path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot\\images\\Posts",
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Posts/{file}";
                }

                //TODO: chnge for logged user
                view.Users = await this.userHelper.GetUserByEmailAsync("adavidforero@ucundinamarca.edu.co");
                var posts = this.ToPost(view, path);
                await this.postRepository.CreateAsync(posts);
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        private Posts ToPost(PostViewModel view, string path)
        {
            return new Posts
            {
                Id = view.Id,
                IdUser = view.IdUser,
                ImageUrl = path,
                Text = view.Text,
                Data = view.Data,
                Users = view.Users
            };
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await this.postRepository.GetByIdAsync(id.Value);
            if (posts == null)
            {
                return NotFound();
            }

            var view = this.ToPostViewModel(posts);
            return View(view);
        }

        private PostViewModel ToPostViewModel(Posts posts)
        {
            return new PostViewModel
            {
                Id = posts.Id,
                IdUser = posts.IdUser,
                ImageUrl = posts.ImageUrl,
                Text = posts.Text,
                Data = posts.Data,
                Users = posts.Users
            };
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,Text,ImageUrl,Data")] PostViewModel view)
        {
            if (id != view.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";


                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Posts",
                            file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Posts/{file}";
                    }


                    //TODO: chnge for logged user
                    view.Users = await this.userHelper.GetUserByEmailAsync("adavidforero@ucundinamarca.edu.co");
                    var posts = this.ToPost(view, path);
                    await this.postRepository.UpdateAsync(view);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.postRepository.ExistAsync(view.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(view);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await this.postRepository.GetByIdAsync(id.Value);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await this.postRepository.GetByIdAsync(id);
            await this.postRepository.DeleteAsync(posts);
            return RedirectToAction(nameof(Index));
        }
    }
}
