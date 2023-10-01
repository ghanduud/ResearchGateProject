using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data.ViewModels
{
    public class NewPaperDropdownsVM
    {
        public NewPaperDropdownsVM()
        {
            ApplicationUsers = new List<ApplicationUser>();
        }
       
        public List<ApplicationUser> ApplicationUsers { get; set; }
    }
}
