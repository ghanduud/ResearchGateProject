using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Models
{
    public class ApplicationUser_Paper
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string PaperId { get; set; }
        public Paper Paper { get; set; }

    }
}
