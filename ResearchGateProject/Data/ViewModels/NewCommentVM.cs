using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data.ViewModels
{
    public class NewCommentVM
    {
        [Key]
        public String Id { get; set; }

        [Display(Name = "Comment")]
        [Required(ErrorMessage = "Comment is required")]
        public string Body { get; set; }

        //Comment
        public string PaperId { get; set; }

        //Auther
        public string ApplicationUserId { get; set; }

        
    }
}
