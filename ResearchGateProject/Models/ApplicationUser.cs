using Microsoft.AspNetCore.Identity;
using ResearchGateProject.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Models
{
    public class ApplicationUser : IdentityUser, IEntityBase
    {
       
        [Display(Name = "Profile Picture")]
        // [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 50 chars")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 chars")]
        public string LastName { get; set; }

        [Display(Name = "University")]
        [Required(ErrorMessage = "University is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "University must be between 3 and 50 chars")]
        public string Uni { get; set; }

        [Display(Name = "Department")]
        //[Required(ErrorMessage = "Department is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Department must be between 3 and 50 chars")]
        public string Dept { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 chars")]
        public string Email { get; set; }



        //Relationships
        public List<ApplicationUser_Paper> ApplicationUsers_Papers { get; set; }
        //public ApplicationUser ApplicationUser { get; internal set; }
    }
}
