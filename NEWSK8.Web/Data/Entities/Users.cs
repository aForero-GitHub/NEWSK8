using Microsoft.AspNetCore.Identity;
using System;

namespace NEWSK8.Web.Data.Entities
{
    public class Users : IdentityUser

    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
