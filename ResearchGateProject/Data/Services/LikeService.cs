using ResearchGateProject.Data.Base;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data.Services
{
    public class LikeService : EntityBaseRepository<Like>, ILikeService
    {

        private readonly AppDbContext _context;
        public LikeService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewLikeAsync(Like data)
        {            
            var newlike = new Like()
            {
                Id = data.Id,
                Type = data.Type,
                PaperId = data.PaperId,
                ApplicationUserId = data.ApplicationUserId

            };
            await _context.Likes.AddAsync(newlike);
            await _context.SaveChangesAsync();




        }


    }
}
