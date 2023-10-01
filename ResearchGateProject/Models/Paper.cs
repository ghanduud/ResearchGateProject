using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ResearchGateProject.Data.Base;

namespace ResearchGateProject.Models
{
    public class Paper : IEntityBase
    {

        [Key]
        public String Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        //for Created date
        public DateTime CreatedDate { get; set; }

        //Relationships
        //public ApplicationUser_Paper ApplicationUser_Paper { get; set; }
        public List<ApplicationUser_Paper> ApplicationUsers_Papers { get; set; }

        //Relationships
        public List<Comment> Comments { get; set; }

        //Relationships
        public List<Like> Likes { get; set; }
        




    }
}
