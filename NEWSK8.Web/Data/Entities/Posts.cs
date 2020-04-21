namespace NEWSK8.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Posts : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        public IEnumerable<Likes> Items { get; set; }

        [Display(Name = "Likes")]
        public double NumberLikes { get { return this.Items == null ? 0 : this.Items.Sum(i => i.NumberLikes); } }

        public Users Users { get; set; }

        public Posts Post { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }
                //TODO: se debe cambiar por la URL correcta
                return $"https://newsk8webudec.azurewebsites.net{this.ImageUrl.Substring(1)}";
            }
        }
    }
}
