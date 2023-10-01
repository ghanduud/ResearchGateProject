using ResearchGateProject.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Models
{
    public class Comment : IEntityBase
    {
        [Key]
        public String Id { get; set; }

        [Display(Name = "Body")]
        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }

        //Paper
        public String PaperId { get; set; }
        [ForeignKey("PaperId")]
        public Paper Paper { get; set; }

        //ApplicationUser
        public String ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }



    }
}
