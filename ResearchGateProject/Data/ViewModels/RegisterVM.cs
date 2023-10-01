using System.ComponentModel.DataAnnotations;


namespace ResearchGateProject.Data.ViewModels
{
    public class RegisterVM
    {

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

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Mobile is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Mobile must be between 3 and 50 chars")]
        public string Mobile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 chars")]
        public string Email { get; set; }
      
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
