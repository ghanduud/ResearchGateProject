using ResearchGateProject.Data.Base;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data.Services
{
    public interface ILikeService : IEntityBaseRepository<Like>
    {
        Task AddNewLikeAsync(Like data);
    }
}

