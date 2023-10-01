using ResearchGateProject.Data.Base;
using ResearchGateProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchGateProject.Data.Services
{
    public class ApplicationUsersService : EntityBaseRepository<ApplicationUser>, IApplicationUsersService
    {
        private readonly AppDbContext _context;
        public ApplicationUsersService(AppDbContext context) : base(context) {

            _context = context;
        }

        public async Task<ApplicationUser> GetAuthersByIdAsync(string id)
        {          
            var AutherInfo = await _context.ApplicationUsers
                .Include(am => am.ApplicationUsers_Papers).ThenInclude(a => a.ApplicationUser)
                .FirstOrDefaultAsync(n => n.Id == id);

            return AutherInfo;
        }
    }
}
