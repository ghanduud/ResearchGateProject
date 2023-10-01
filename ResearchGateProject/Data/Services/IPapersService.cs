using ResearchGateProject.Data.Base;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResearchGateProject.ViewModel;

namespace ResearchGateProject.Data.Services
{
    public interface IPapersService:IEntityBaseRepository<Paper>
    {
        Task<Paper> GetPaperByIdAsync(string id);
        Task<NewPaperDropdownsVM> GetNewPaperDropdownsValues();
        Task AddNewPaperAsync(NewPaperVM data);
    }
}
