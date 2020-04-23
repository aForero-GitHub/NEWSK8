using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace NEWSK8.Web.Data.Entities
{
    public class Users : IdentityUser

    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        [Display(Name = "User")]
        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }
    }
}
