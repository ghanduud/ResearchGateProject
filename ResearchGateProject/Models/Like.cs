using ResearchGateProject.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Models
{
    public class Like : IEntityBase
    {
        [Key]
        public String Id { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

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
