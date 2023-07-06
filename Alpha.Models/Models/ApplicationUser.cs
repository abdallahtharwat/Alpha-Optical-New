using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha.Models.Models
{
    public class ApplicationUser : IdentityUser     // add more fields in register page in website  ( step 1  create model with name applicationuser and put all other fields )    ( step2 replace identityuser by application user in ragister controller)   (step 3 add this new fields in input method in register controller)      (step4 save this new fields in post method)        
    {
        [Required]
        public string Name { get; set; }       
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public int? CompanyId { get; set; } // (step 1) to add forenkey in register
        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company? Company { get; set; }

        [NotMapped]
        public string Role { get; set; }

    }
}
