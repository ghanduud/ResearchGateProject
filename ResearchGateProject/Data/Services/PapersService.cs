using ResearchGateProject.Data.Base;
using ResearchGateProject.Data.ViewModels;
using ResearchGateProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResearchGateProject.ViewModel;

namespace ResearchGateProject.Data.Services
{
    public class PapersService : EntityBaseRepository<Paper>, IPapersService
    {
        private readonly AppDbContext _context;
        public PapersService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPaperAsync(NewPaperVM data)
        {
            var newPaper = new Paper()
            {
                Id = data.Id,   
                Title = data.Title,
                Body = data.Body,
                CreatedDate = data.CreatedDate
                


            };
            await _context.Papers.AddAsync(newPaper);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var applicationUserId in data.ApplicationUserIds)
            {
                var newAutherPaper = new ApplicationUser_Paper()
                {
                    PaperId = newPaper.Id,
                    ApplicationUserId = applicationUserId
                };
                await _context.ApplicationUsers_Papers.AddAsync(newAutherPaper);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Paper> GetPaperByIdAsync(string id)
        {
            var PaperDetails = await _context.Papers
                .Include(am => am.ApplicationUsers_Papers).ThenInclude(a => a.ApplicationUser)
                .FirstOrDefaultAsync(n => n.Id == id);

            return PaperDetails;
        }

        public async Task<NewPaperDropdownsVM> GetNewPaperDropdownsValues()
        {
            var response = new NewPaperDropdownsVM()
            {
                ApplicationUsers = await _context.ApplicationUsers.OrderBy(n => n.FirstName).ToListAsync()
            };

            return response;
        }

       
    }
}
