namespace NEWSK8.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Comments : IEntity
    {
        public int Id { get; set; }

        [Required]
        public Users Users { get; set; }

        [Required]
        public Posts Posts { get; set; }

        [Display(Name = "Comment")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }

        public IEnumerable<Likes> Items { get; set; }

        [Display(Name = "Likes")]
        public double NumberLikes { get { return this.Items == null ? 0 : this.Items.Sum(i => i.NumberLikes); } }


    }
}
