using System.ComponentModel.DataAnnotations;

namespace ResearchGateProject.Data.ViewModels
{
    public class UserVM
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
        public string University { get; set; }

        [Display(Name = "Department")]
        //[Required(ErrorMessage = "Department is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Department must be between 3 and 50 chars")]
        public string Department { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 chars")]
        public string Email { get; set; }



        //Relationships
        //public List<ApplicationUser_Paper> ApplicationUsers_Papers { get; set; }
    }
}
