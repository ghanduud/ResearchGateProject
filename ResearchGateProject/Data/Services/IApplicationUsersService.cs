using ResearchGateProject.Data.Base;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data.Services
{
    public interface IApplicationUsersService:IEntityBaseRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetAuthersByIdAsync(string id);
    }
}
