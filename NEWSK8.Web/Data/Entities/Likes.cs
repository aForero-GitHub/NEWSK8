using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NEWSK8.Web.Data.Entities
{
    public class Likes : IEntity
    {
        public int Id { get; set; }

        [Required]
        public Users Users { get; set; }

        [Required]
        public Posts Posts { get; set; }

        [Required]
        public Comments Comments { get; set; }

        [Display(Name = "Comment")]
        public string Text { get; set; }

        [Required]
        [Display(Name = "fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }

        public double NumberLikes { get; set; }
    }
}
