using ResearchGateProject.Models;
using System.Collections.Generic;

namespace ResearchGateProject.Data.ViewModels
{
    public class Paper_comentsVM
    {
        public string PaperId { get; set; }
        public Paper paper { get; set; }
        public IEnumerable<Paper> papers { get; set; }

        public Like Like { get; set; }
        public int NumbersOfLike { get; set; }
        public int NumbersOfDisLike { get; set; }

        public Comment Comment { get; set; }
        public IEnumerable<Comment> coments { get; set; }

        //Auther
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUser { get; set; }
    }
}
