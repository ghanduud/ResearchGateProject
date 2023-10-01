using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ResearchGateProject.ViewModel
{
    public class NewPaperVM
    {
        [Key]
        public string Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Display(Name = "Paper Body")]
        [Required(ErrorMessage = "Description is required")]
        public string Body { get; set; }

        //for Created date
        [Display(Name = "Paper date")]
        [Required(ErrorMessage = "Paoer date is required")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Select Auther(s)")]
        [Required(ErrorMessage = "Peper Auther(s) is required")]
        public List<string> ApplicationUserIds { get; set; }

        ////Relationships
        //public List<ApplicationUser_Paper> ApplicationUsers_Papers { get; set; }

        ////Comment
        //public String CommentId { get; set; }

        ////Like
        //public String LikeId { get; set; }
    }
}
