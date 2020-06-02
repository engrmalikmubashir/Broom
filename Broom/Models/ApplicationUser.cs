using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Broom.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Office Phone")]
        [StringLength(15)]
        public string PhoneNumber2 { get; set; }

        [NotMapped]
        public bool IsAdmin { get; set; }
    }
}
