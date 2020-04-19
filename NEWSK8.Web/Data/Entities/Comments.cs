namespace NEWSK8.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

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

        public string IdUser { get; set; }

        [Required]
        public string IdPost { get; set; }

    }
}
