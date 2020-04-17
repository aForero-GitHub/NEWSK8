using System;
using System.ComponentModel.DataAnnotations;

namespace NEWSK8.Web.Data.Entities
{
    public class Posts : IEntity
    {
        public int Id { get; set; }
        public string IdUser { get; set; }
        public string Text { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Date")]
        public DateTime? Data { get; set; }

        public Users Users { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }

                return $"https://newsk8webudec.azurewebsites.net{this.ImageUrl.Substring(1)}";
            }
        }
    }
}
