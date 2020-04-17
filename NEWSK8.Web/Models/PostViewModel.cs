namespace NEWSK8.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using Data.Entities;
    using System.ComponentModel.DataAnnotations;

    public class PostViewModel : Posts
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
